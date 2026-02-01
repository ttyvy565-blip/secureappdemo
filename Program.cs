using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace SecureAppDemo
{
    static class Program
    {
        static readonly HashSet<string> AllowedCommands = new()
        {
            "whoami",
            "date"
        };

        static void Main(string[] args)
        {
            Console.Write("Enter command: ");
            string? cmd = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cmd) || !AllowedCommands.Contains(cmd))
            {
                Console.WriteLine("Command not allowed.");
                return;
            }

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = cmd,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred.");
            }
        }
    }
}
