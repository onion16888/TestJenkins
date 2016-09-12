using System;
using System.Collections.Generic;
namespace TestJenkins
{
	public interface IBeerSearcher
	{
		IList<Beer> FindBeers(string query);	
	}
}

