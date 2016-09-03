using CefSharp;

namespace SolidCubes.WebUtils.Handlers
{
    internal class LifeSpanHandler : ILifeSpanHandler
    {
        private MainForm myForm;

        public LifeSpanHandler(MainForm form)
        {
            myForm = form;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            //TODO: Allow some popups? Open in New tab? Filter  mailto:  and others ? For now it works...

            myForm.Url_Load(targetUrl);
            newBrowser = null;
            return true;
        }
    }
}
