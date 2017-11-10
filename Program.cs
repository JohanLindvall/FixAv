namespace FixAv
{
    using Topshelf;

    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<FixAv>(s =>
                {
                    s.ConstructUsing(name => new FixAv());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("FixAV");
                x.SetDisplayName("FixAV");
                x.SetServiceName("FixAV");
            });
        }
    }
}
