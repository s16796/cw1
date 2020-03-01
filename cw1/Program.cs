using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var doc = await httpClient.GetStringAsync(args[0]);
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            MatchCollection collection = emailRegex.Matches(doc);
            foreach(Match match in collection)
            {
                Console.WriteLine(match);
            }
        }
    }
}
