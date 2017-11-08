namespace FixAv
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    if (process.MainModule.FileName.StartsWith(@"C:\Program Files (x86)\Sophos"))
                    {
                        if (process.PriorityClass != ProcessPriorityClass.Idle)
                        {
                            Console.WriteLine($@"Setting '{process.ProcessName}' ProcessPriorityClass.Idle");
                            process.PriorityClass = ProcessPriorityClass.Idle;
                        }
                    }
                }
                catch (Win32Exception)
                {
                }
                catch (InvalidOperationException)
                {
                }
            }
        }
    }
}
