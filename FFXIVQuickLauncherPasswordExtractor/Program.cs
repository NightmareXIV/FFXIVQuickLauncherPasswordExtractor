using AdysTech.CredentialManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVQuickLauncherPasswordExtractor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FFXIV Quick launcher password extractor");
            while (true)
            {
                Console.WriteLine("Type your username to attempt to view password. Type \"exit\" to exit.");
                var a = Console.ReadLine();
                if (a.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;
                try
                {
                    var credentials = CredentialManager.GetCredentials($"FINAL FANTASY XIV-{a.ToLower()}");
                    if(credentials == null)
                    {
                        Console.WriteLine("Not found");
                    }
                    else
                    {
                        Console.WriteLine($"Password: {credentials.Password}");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}
