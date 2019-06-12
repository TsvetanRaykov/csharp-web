using System.Globalization;
using System.Threading;
using SIS.MvcFramework;

namespace MyMusaca.Web
{
    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            WebHost.Start(new Startup());
        }
    }
}
