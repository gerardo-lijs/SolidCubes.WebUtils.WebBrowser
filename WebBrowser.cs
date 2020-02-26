using CefSharp;
using CefSharp.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SolidCubes.WebUtils
{
    public static class WebBrowser
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: Get config from CommandLine Arguments

            // Test config
            var conf = new WebBrowserConfig
            {
                StarUrl = "https://dotnet.microsoft.com/"
            };
            conf.DomainConstraint.Add("*.dotnet.microsoft.com");

            // Init
            Init_Cef();

            // Run
            Application.Run(new MainForm(conf));
        }

        public static void Open(string startUrl, bool modal = false, params string[] domainConstraint)
        {
            var conf = new WebBrowserConfig
            {
                StarUrl = startUrl,
                Modal = modal,
                DomainConstraint = domainConstraint.ToList()
            };

            Open(conf);
        }

        public static void Open(WebBrowserConfig config)
        {
            Init_Cef();

            var myForm = new MainForm(config);
            if (config.Modal)
                myForm.ShowDialog();
            else
                myForm.Show();
        }

        private static void Init_Cef()
        {
            var settings = new CefSettings();

            // TODO: Implement Custom Scheme to avoid MessageBox Error and redirect to:  browser://error/notallowed.html
            //settings.RegisterScheme(new CefCustomScheme
            //{
            //    SchemeName = SchemeHandlerFactory.SchemeNameBrowser,
            //    SchemeHandlerFactory = new SchemeHandlerFactory()
            //});

            Cef.Initialize(settings);
        }
    }
}
