using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidCubes.WebUtils.Handlers
{
    /// <summary>
    /// Disable RightClick Menu in Webpages
    /// </summary>
    internal class CustomContextHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, CefSharp.IBrowser browser, IFrame frame, IContextMenuParams parameters,
            IMenuModel model)
        {
            model.Clear();
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, CefSharp.IBrowser browser, IFrame frame, IContextMenuParams parameters,
            CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, CefSharp.IBrowser browser, IFrame frame)
        {
            return;
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }

}
