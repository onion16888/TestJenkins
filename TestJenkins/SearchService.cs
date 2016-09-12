using System;
using System.Collections.Generic;

namespace TestJenkins
{
	public class SearchService
	{
		private readonly IBeerSearcher _beerSearcher;
		private readonly IDictionary<string, IList<Beer>> _searchCashe = new Dictionary<string, IList<Beer>>();

		public SearchService(IBeerSearcher beerSearcher)
		{
			_beerSearcher = beerSearcher;
		}

		public IList<Beer> FindBeers(string query)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return new List<Beer>();
			}

			if (_searchCashe.ContainsKey(query))
			{
				return _searchCashe[query];
			}

			var beers = _beerSearcher.FindBeers(query);

			_searchCashe[query] = beers;

			return beers;
		}
	}
}

