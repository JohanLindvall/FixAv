namespace FixAv
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Threading;

    public class FixAv
    {
        private Timer timer;

        public void Start() { this.timer = new Timer(state => this.Fix(), null, TimeSpan.Zero, TimeSpan.FromMinutes(15)); }

        public void Stop() { this.timer.Dispose(); }

        public void Fix()
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
