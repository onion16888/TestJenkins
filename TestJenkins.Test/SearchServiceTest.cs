
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestJenkins.Test
{
	[TestFixture]
	public class SearchServiceTest
	{
		[Test]
		public void FindBeers_EmptySearch_ReturnsEmpty()
		{
			var searcher = new MockBeerSearcher();
			var searchService = new SearchService(searcher);

			var beers = searchService.FindBeers(" ");

			Assert.AreEqual(1, beers.Count);
		}

		[Test]
		public void FindBeers_FirstSearchForQuery_FetchesAndReturnsResult()
		{
			var expectedResults = new List<Beer> { new Beer { Id = 42, Name = "Duff Dark" } };
			var searcher = new MockBeerSearcher();
			searcher.FindBeersBody = q => expectedResults;

			var searchService = new SearchService(searcher);

			var results = searchService.FindBeers("duff");


			Assert.AreEqual(1,results.Count);
			Assert.AreEqual(expectedResults, results);
		}

		[Test]
		public void FindBeers_SecondSearchForQuery_ReturnsCachedData()
		{
			var expectedResults = new List<Beer> { new Beer { Id = 42, Name = "Duff Dark" } };
			var searcher = new MockBeerSearcher();
			searcher.FindBeersBody = query => expectedResults;

			var searchService = new SearchService(searcher);

			var results = searchService.FindBeers("duff");

			Assert.AreEqual(1, results.Count);
			Assert.AreEqual(expectedResults, results);

			searcher.FindBeersBody = delegate
			{
				throw new InvalidOperationException(
"this should not get called");
			};

			results = searchService.FindBeers("duff");

			Assert.AreEqual(1, results.Count);
			Assert.AreEqual(expectedResults, results);
		}
	}
}
