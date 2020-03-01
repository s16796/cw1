using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.GetAsync("https://www.pja.edu.pl/");

            if (res.IsSuccessStatusCode)
            {
                string html = await res.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(html);
                foreach(var m in matches)
                {
                    Console.WriteLine(m.ToString());
                }

            }

            Console.WriteLine("Koniec!");


            //Wlasne rozwiązanie napisane przed omówieniem na lekcji
            /*
            string doc = await httpClient.GetStringAsync(args[0]); //"https://www.pja.edu.pl/" przekazane w argumencie
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            MatchCollection collection = emailRegex.Matches(doc);
            foreach(Match match in collection)
            {
                Console.WriteLine(match);
            }
            */
        }
    }
}
