using CefSharp;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SolidCubes.WebUtils
{
    public class WebBrowser
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TODO: Get config from CommandLine Arguments

            //test config
            var conf = new WebBrowserConfig();
            conf.StarUrl = "http://www.asp.net/";
            conf.DomainConstraint.Add("*.asp.net");

            //init
            Init_Cef();

            //run
            Application.Run(new MainForm(conf));
        }

        public static void Open(string StartUrl, bool Modal = false, params string[] DomainConstraint)
        {
            var conf = new WebBrowserConfig();
            conf.StarUrl = StartUrl;
            conf.Modal = Modal;
            conf.DomainConstraint = DomainConstraint.ToList();

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
            CefSettings settings = new CefSettings();

            //TODO: Implement Custom Scheme to avoid MessageBox Error and redirect to:  browser://error/notallowed.html
            //settings.RegisterScheme(new CefCustomScheme
            //{
            //    SchemeName = SchemeHandlerFactory.SchemeNameBrowser,
            //    SchemeHandlerFactory = new SchemeHandlerFactory()
            //});

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, shutdownOnProcessExit: false, performDependencyCheck: true);
        }
    }
}