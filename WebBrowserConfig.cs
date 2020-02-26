using System.Collections.Generic;

namespace SolidCubes.WebUtils
{
    public sealed class WebBrowserConfig
    {
        // TODO: AllowPopUp? Same Window? New Window?
        // TODO: AllowContextMenu?
        // TODO: Print?
        // TODO: etc, etc

        public string StarUrl { get; set; }
        public bool Modal { get; set; }
        /// <summary>
        /// List of Allowed domains. You can user * as wilcard. Don't include http:// or https:// or / at then end. Just the domain.
        /// Example: github.com  /  *.google.com
        /// </summary>
        public List<string> DomainConstraint { get; set; } = new List<string>();
        public string WindowTitle { get; set; } = "SolidCubes WebBrowser";
    }
}
