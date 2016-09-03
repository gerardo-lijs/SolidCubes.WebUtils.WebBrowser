using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using SolidCubes.WebUtils.Controls;

namespace SolidCubes.WebUtils
{
    internal partial class MainForm : Form
    {
        private readonly ChromiumWebBrowser browser;
        private readonly WebBrowserConfig _config;

        public MainForm(WebBrowserConfig config)
        {
            InitializeComponent();

            //save config
            _config = config;

            this.Text = config.WindowTitle;
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            //controls
            Tx_Url.ReadOnly = true;
            Tx_Url.BackColor = System.Drawing.SystemColors.Window;

            //browser
            browser = new ChromiumWebBrowser(config.StarUrl)
            {
                Dock = DockStyle.Fill,
            };
            content.Controls.Add(browser);

            browser.LoadingStateChanged += Browser_LoadingStateChanged;
            browser.TitleChanged += Browser_TitleChanged;
            browser.AddressChanged += Browser_URLChanged;
            browser.MenuHandler = new Handlers.CustomContextHandler();
            browser.LifeSpanHandler = new Handlers.LifeSpanHandler(this);
        }

        public void Url_Load(string Url)
        {
            browser.Load(Url);
        }

        private void Browser_URLChanged(object sender, AddressChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                Check_DomainConstraint(e.Address);

                Tx_Url.Text = e.Address;

                SetCanGoBack(browser.CanGoBack);
                SetCanGoForward(browser.CanGoForward);

                this.Text = "Loading...";
            });
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                this.Text = $"SolidCubes WebBrowser - {e.Title}";
            });
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            SetCanGoBack(e.CanGoBack);
            SetCanGoForward(e.CanGoForward);

            if (e.IsLoading)
            {
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    Bt_Refresh.Visible = false;
                    Bt_Stop.Visible = true;
                });
            }
            else
            {
                //enable buttons
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    Bt_Refresh.Visible = true;
                    Bt_Stop.Visible = false;
                });
            }
        }

        private void Check_DomainConstraint(string UrlAddress)
        {
            //TODO: Maybe it's possible to Block using CustomScheme or some decent code. For the time being, this low-quality code more or less works and get the job done

            bool bAllowed = false;

            //Check Constraints
            foreach (var item in _config.DomainConstraint)
            {
                string strNewWeb = browser.Address;
                string strPrefixFlex = item;

                //Flex Method
                if (item.Contains("*"))
                {
                    //Remove http / https
                    strNewWeb = strNewWeb.Replace("http://", "");
                    strNewWeb = strNewWeb.Replace("https://", "");

                    //Split
                    if (strNewWeb.Contains("/"))
                    {
                        strNewWeb = strNewWeb.Split('/')[0];
                    }

                    strPrefixFlex = strPrefixFlex.Replace("*", "");

                    //Compare
                    strNewWeb = strNewWeb.Substring(strNewWeb.Length - strPrefixFlex.Length);
                }
                else
                {
                    //Compare
                    strNewWeb = strNewWeb.Substring(0, Math.Min(strNewWeb.Length, strPrefixFlex.Length));
                }

                if (strNewWeb == strPrefixFlex)
                {
                    bAllowed = true;
                    break;
                }
            }

            //check constraints
            if (!bAllowed)
            {
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    //TODO: Language
                    MessageBox.Show(text: $"Browsing not allowed to the following website: {browser.Address}" + Environment.NewLine + Environment.NewLine + "Click OK and the Browser will close.",
                                    caption: "SolidCubes WebBrowser",
                                    buttons: MessageBoxButtons.OK,
                                    icon: MessageBoxIcon.Warning);
                    this.Close();
                });
            }
        }

        private void SetCanGoBack(bool canGoBack)
        {
            this.InvokeOnUiThreadIfRequired(() => Bt_Back.Enabled = canGoBack);
        }

        private void SetCanGoForward(bool canGoForward)
        {
            this.InvokeOnUiThreadIfRequired(() => Bt_Forward.Enabled = canGoForward);
        }

        private void Bt_Back_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void Bt_Forward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void Bt_Print_Click(object sender, EventArgs e)
        {
            browser.Print();
        }

        private void Bt_Refresh_Click(object sender, EventArgs e)
        {
            browser.Load(browser.Address);
        }

        private void Bt_Stop_Click(object sender, EventArgs e)
        {
            browser.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser.Dispose();
            Cef.Shutdown();
        }
    }
}