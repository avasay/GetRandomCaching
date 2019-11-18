using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GetRandomCaching
{
    public class DirInfoCacher
    {
        public DirInfoCacher()
        {
        }

        public string GetRandom()
        {
            object cacheList = HttpRuntime.Cache.Get("biology") as List<string>;
            string returnedString = string.Empty;

            if (cacheList == null)
            {
                // Initialize our list
                List<string> myList = new List<string>(new string[] { "biology-1", "biology-2", "biology-3" });

                // Cache the 
                HttpRuntime.Cache.Insert("biology", myList, null, DateTime.Now.AddMinutes(60d), System.Web.Caching.Cache.NoSlidingExpiration);

                Random R = new Random();

                // get random number from 0 to 2. 
                int someRandomNumber = R.Next(0, myList.Count());
                returnedString = myList.ElementAt(someRandomNumber);
                return returnedString;
            }
            else
            {
                IList<string> objectCache = (IList<string>)cacheList;

                Random R = new Random();

                // get random number from 0 to 2. 
                int someRandomNumber = R.Next(0, objectCache.Count());

                returnedString = objectCache.ElementAt(someRandomNumber);

                return returnedString;
            }

        }
    }
}