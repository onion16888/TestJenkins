using System;
using System.Collections.Generic;

namespace TestJenkins.Test
{
	public class MockBeerSearcher:IBeerSearcher
	{
		public Func<string, IList<Beer>> FindBeersBody { get; set; }

		public IList<Beer> FindBeers(string query)
		{
			return FindBeersBody(query);
		}
	}
}

