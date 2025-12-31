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
                Console.WriteLine("Type your username to attempt to view password. Type \"exit\" to exit, \"list\" - to list all available credentials.");
                var a = Console.ReadLine();
                if (a.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;
                if(a.Equals("list"))
                {
                    try
                    {
                        var credentials = CredentialManager.EnumerateICredentials().Where(x => x.UserName != "" || x.TargetName != "");

                        Console.WriteLine($"Found {credentials.Count()} credentials:\n");

                        foreach(var cred in credentials)
                        {
                            Console.WriteLine($"Target: {cred.TargetName}");
                            Console.WriteLine($"Username: {cred.UserName}");
                            Console.WriteLine($"Password: {CredentialManager.GetCredentials(cred.TargetName)?.Password}");
                            Console.WriteLine();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                try
                {
                    var credentials = CredentialManager.GetCredentials($"FINAL FANTASY XIV-{a.ToLower()}") 
                        ?? CredentialManager.GetCredentials($"XIVLAUNCHER-{a.ToLower()}")
                        ?? CredentialManager.GetCredentials($"XIVLAUNCHERCN-{a.ToLower()}")
                        ?? CredentialManager.GetCredentials($"{a.ToLower()}")
                        ?? CredentialManager.GetCredentials($"{a}");
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
