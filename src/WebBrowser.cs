using CefSharp;
using CefSharp.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;
using CommandLine;
using System.Collections.Generic;
using CommandLine.Text;

namespace SolidCubes.WebUtils
{
    public static class WebBrowser
    {
        private class Options
        {
            [Option('s', "start-url", Default = true, Required = true, HelpText = "Start URL.")]
            public string StarUrl { get; set; }

            [Option('a', "allow", Required = true, HelpText = "Domains allowed to browse.")]
            public IEnumerable<string> DomainsAllowed { get; set; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            // Example: --start-url https://dotnet.microsoft.com --allow *.dotnet.microsoft.com
            // Example: --start-url https://dotnet.microsoft.com --allow *.dotnet.microsoft.com *.microsoft.com

            try
            {
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(RunOptions)
                    .ThrowOnParseError();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void RunOptions(Options opts)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test config
            var conf = new WebBrowserConfig
            {
                StarUrl = opts.StarUrl
            };
            conf.DomainsAllowed = new List<string>(opts.DomainsAllowed);

            // Init
            Init_Cef();

            // Run
            Application.Run(new MainForm(conf));
        }

        public static ParserResult<T> ThrowOnParseError<T>(this ParserResult<T> result)
        {
            if (!(result is NotParsed<T>))
            {
                // Case with no errors needs to be detected explicitly, otherwise the .Select line will throw an InvalidCastException
                return result;
            }

            var builder = SentenceBuilder.Create();
            var errorMessages = HelpText.RenderParsingErrorsTextAsLines(result, builder.FormatError, builder.FormatMutuallyExclusiveSetErrors, 1);

            var excList = errorMessages.Select(msg => new ArgumentException(msg)).ToList();

            if (excList.Any())
            {
                var errorText = "Invalid command line parameters:\n";
                foreach (var item in excList)
                {
                    errorText += "\n" + item.Message;
                }
                errorText += "\n\nExample: --start-url https://dotnet.microsoft.com --allow *.dotnet.microsoft.com";
                MessageBox.Show(text: errorText,
                                caption: "SolidCubes WebBrowser",
                                buttons: MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Error);
            }

            return result;
        }

        public static void Open(string startUrl, bool modal = false, params string[] domainsAllowed)
        {
            var conf = new WebBrowserConfig
            {
                StarUrl = startUrl,
                Modal = modal,
                DomainsAllowed = domainsAllowed.ToList()
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
            // NOTE: Also requires C++ Redist 2015 to work.
            var settings = new CefSettings();

            Cef.Initialize(settings);
        }
    }
}
