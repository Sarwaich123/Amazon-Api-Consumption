using Nager.AmazonProductAdvertising;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumeApiSolution
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome To Amazon Advertising Apis Services");
            Console.WriteLine("Enter Secret Key");
            string secretkey = Console.ReadLine();
            Console.WriteLine("Enter access Key");
            string accessKey = Console.ReadLine();
            Console.WriteLine("Enter Partner-tag Key");
            string partnertag = Console.ReadLine();
            int selection = display();
            Methods mm = new Methods();
            if (selection == 1)
            {
                Console.WriteLine("Enter Keyword to Search");
                string keyword = Console.ReadLine();
                var result = new List<string>(100);
                result = await mm.Searchitems(keyword, secretkey, accessKey, partnertag);
                Console.WriteLine(result);
            }
            else if (selection==2)
            {//Getitems....
                Console.WriteLine("Enter ASIN to Search");
                string asin = Console.ReadLine();
                string result = await mm.Getitems(asin, secretkey, accessKey, partnertag);
                Console.WriteLine(result);

            }
            else if (selection == 3)
            {
                Console.WriteLine("Enter ASIN to Search");
                string asin = Console.ReadLine();
                string result = await mm.GetVariations(asin, secretkey, accessKey, partnertag);
                Console.WriteLine(result);
            }
            else if (selection == 4)
            {
                string[] nodess= GetNodes();
                string result = await mm.Browsernodes(nodess, secretkey, accessKey, partnertag);
                Console.WriteLine(result);
            }
            else
            { 
                Console.WriteLine("You have selected wrong number");
                Console.WriteLine("Do you want to try again press Y to try again");
                string value=Console.ReadLine();
                if(value=="Y")
                {
                    await Main(args);
                }
            }

        }

        static public int display()
        {
            
            Console.WriteLine("Select service you want to avail?");
            Console.WriteLine("1:Searchitems");
            Console.WriteLine("2:Getitems");
            Console.WriteLine("3:GetVariations");
            Console.WriteLine("4:GetNodes");
            string response = Console.ReadLine();
            int final_response = Convert.ToInt32(response);
            return final_response;
        }


        public static string[] GetNodes()
        {

            var names = new List<string>();
          //  int index = 0;
            string decision = "W";
            do
            {
             //   Console.WriteLine(index);
                Console.WriteLine("Enter Node value");
                string value = Console.ReadLine();
                names.Add(value);
              //  index++;
                Console.WriteLine("Do you want to add more Node? if Yes press any key..if No press N");
                decision = Console.ReadLine();

            } while (decision != "N");
            //  Console.WriteLine(nodes);
            //  return nodes;
            var nameArray = names.ToArray();
            return nameArray;
        }




    }
}
