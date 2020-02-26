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

            // Save config
            _config = config;

            Text = config.WindowTitle;
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            // Controls
            Tx_Url.ReadOnly = true;
            Tx_Url.BackColor = System.Drawing.SystemColors.Window;

            // Browser
            browser = new ChromiumWebBrowser(config.StarUrl)
            {
                Dock = DockStyle.Fill,
            };
            content.Controls.Add(browser);

            browser.LoadingStateChanged += Browser_LoadingStateChanged;
            browser.TitleChanged += Browser_TitleChanged;
            browser.AddressChanged += Browser_AddressChanged;
            browser.MenuHandler = new Handlers.CustomContextHandler();
            browser.LifeSpanHandler = new Handlers.LifeSpanHandler(this);
        }

        public void Url_Load(string url)
        {
            browser.Load(url);
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (!IsDomainAllowed(e.Address))
                {
                    // TODO: Show error when browser is hidden
                    browser.Visible = false;

                    // TODO: Language
                    MessageBox.Show(text: $"Browsing not allowed to the following website: {browser.Address}" + Environment.NewLine + Environment.NewLine + "Click OK and the Browser will close.",
                                    caption: "SolidCubes WebBrowser",
                                    buttons: MessageBoxButtons.OK,
                                    icon: MessageBoxIcon.Warning);
                    Close();
                }

                Tx_Url.Text = e.Address;

                SetCanGoBack(browser.CanGoBack);
                SetCanGoForward(browser.CanGoForward);

                Text = "SolidCubes WebBrowser - Loading...";
            });
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                Text = $"SolidCubes WebBrowser - {e.Title}";
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
                // Enable buttons
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    Bt_Refresh.Visible = true;
                    Bt_Stop.Visible = false;
                });
            }
        }

        private bool IsDomainAllowed(string urlAddress)
        {
            foreach (var item in _config.DomainConstraint)
            {
                var strNewWeb = urlAddress;
                var strPrefixFlex = item;

                // Flex Method
                if (item.Contains("*"))
                {
                    // Remove http / https
                    strNewWeb = strNewWeb.Replace("http://", "");
                    strNewWeb = strNewWeb.Replace("https://", "");

                    // Split
                    if (strNewWeb.Contains("/"))
                    {
                        strNewWeb = strNewWeb.Split('/')[0];
                    }

                    strPrefixFlex = strPrefixFlex.Replace("*.", string.Empty);

                    // Compare
                    if (strNewWeb.EndsWith(strPrefixFlex))
                    {
                        // Allowed
                        return true;
                    }
                }
                else
                {
                    // Compare
                    strNewWeb = strNewWeb.Substring(0, Math.Min(strNewWeb.Length, strPrefixFlex.Length));
                }

                if (strNewWeb == strPrefixFlex)
                {
                    // Allowed
                    return true;
                }
            }

            // Not allowed
            return false;
        }

        private void SetCanGoBack(bool canGoBack) => this.InvokeOnUiThreadIfRequired(() => Bt_Back.Enabled = canGoBack);

        private void SetCanGoForward(bool canGoForward) => this.InvokeOnUiThreadIfRequired(() => Bt_Forward.Enabled = canGoForward);

        private void Bt_Back_Click(object sender, EventArgs e) => browser.Back();

        private void Bt_Forward_Click(object sender, EventArgs e) => browser.Forward();

        private void Bt_Print_Click(object sender, EventArgs e) => browser.Print();

        private void Bt_Refresh_Click(object sender, EventArgs e) => browser.Load(browser.Address);

        private void Bt_Stop_Click(object sender, EventArgs e) => browser.Stop();

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser.Dispose();
            Cef.Shutdown();
        }
    }
}
