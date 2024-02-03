using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ConsumeApiSolution
{
   public class Methods
    {
       
  
        public async Task<List<string>> Searchitems(string keyword,string secretkey, string accesskey, string partnertag)
        {
            var authentication = new AmazonAuthentication();
            authentication.AccessKey = "Access-Key";
            authentication.SecretKey = "Secret-Key";
            string partnertag1 = "partnertag"; 
           var client = new AmazonProductAdvertisingClient(authentication, AmazonEndpoint.US, partnertag1);
            var searchRequest = new SearchRequest
            {
                Keywords = keyword,
                ItemPage = 1,
                Resources = new[]
             {
             //https://webservices.amazon.com/paapi5/documentation/search-items.html#resources-parameter
            "Images.Primary.Large",
            "ItemInfo.Title",
            "ItemInfo.Features"
             }
            };
            var result = await client.SearchItemsAsync(searchRequest);
            int abc = result.SearchResult.TotalResultCount;
            Console.WriteLine("Total number of result items are "+abc);
            var names = new List<string>();
            for (int w = 0; w < 10; w++)
            {
                names.Add(result.SearchResult.Items[w].ASIN);
            }
            int l = abc / 10;
            if (l >= 10)
                l = 10;
            if (abc > 10)
            {

                for (int i = 2; i <= l; i++)
                {
                    var searchRequest1 = new SearchRequest
                    {
                        Keywords = keyword,
                        ItemPage = i,
                        Resources = new[]
                    {
                     //You can found all available Resources in the documentation
                    //https://webservices.amazon.com/paapi5/documentation/search-items.html#resources-parameter
                    "Images.Primary.Large",
                    "ItemInfo.Title",
                    "ItemInfo.Features"
                    }
                    };
                    var result1 = await client.SearchItemsAsync(searchRequest1);
                    for (int w = 0; w < 10; w++)
                    {
                        names.Add(result1.SearchResult.Items[w].ASIN);
                       // r++;
                    }

                }
            }

            return names;
        }

        public async Task<string> Getitems(string asin, string secretkey, string accesskey, string partnertag)
        {
            var authentication = new AmazonAuthentication();
            authentication.AccessKey = accesskey;
            authentication.SecretKey = secretkey;
            var client = new AmazonProductAdvertisingClient(authentication, AmazonEndpoint.US, partnertag);
            var result = await client.GetItemsAsync(asin);
            // var result = await client.SearchItemsAsync(as);
            return result.ToString();
        }
        public async Task<string> GetVariations(string asin, string secretkey, string accesskey, string partnertag)
        {
            var authentication = new AmazonAuthentication();
            authentication.AccessKey = accesskey;
            authentication.SecretKey = secretkey;
            var client = new AmazonProductAdvertisingClient(authentication, AmazonEndpoint.US, partnertag);
            var result = await client.GetVariationsAsync(asin);
            // var result = await client.SearchItemsAsync(as);
            return result.ToString();
        }

        public async Task<string> Browsernodes(string[] brow, string secretkey, string accesskey, string partnertag)
        {
            var authentication = new AmazonAuthentication();
            authentication.AccessKey = accesskey;
            authentication.SecretKey = secretkey;
            var client = new AmazonProductAdvertisingClient(authentication, AmazonEndpoint.US, partnertag);
            var result = await client.GetBrowseNodesAsync(brow);
            return result.ToString();
        }
    }
}
