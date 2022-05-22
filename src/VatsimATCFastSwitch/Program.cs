using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatsimATCFastSwitch
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var builder = new ContainerBuilder();
            builder.RegisterModule<WinFormModule>();
            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = container.Resolve<MainForm>();
            Application.Run(mainForm);
        }
    }
}
