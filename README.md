# SolidCubes WebUtils WebBrowser

This is a small browser I needed in order to replace a 10 year old VB6 WebBrowser control since it no longer worked with Internet Explorer ancient version and the website they need to browse!!

It's kind of minimal and there is plenty of room for features to be added and for code to be refactored and improved. Still, I decided to share, in case it's useful for somebody to copy/paste pieces of it or inspire ideas.

The project uses CefSharp 51 (NuGet version) and works on x86 or x64 (read CefSharp blogs about how to compile/debug which each target).

Highlights:

1) Features

	- Allows to restric the browsing to only some domains
	- Uses lastest available version of CefSharp (great compatibility with HTML5, CSS3, Javascript, etc so almost every website works!)
	- Disables right click on web pages
	- Disables PopUps (It actually runs them on the same main browser but you could change to whatever your needs)

2) Run from command line

    If executed as Windows Application if uses Main and takes arguments from command line for Url to Browse and Domains to restrict the user to. Convert to Class Library if you prefer to avoid this.

3) Run with a reference to this Windows Application / Class Library

    using SolidCubes.WebUtils;

    WebBrowser.Open("www.test.com", true, "*.test.com")		//Modal and limited to test.com domain and subdomains

4) Run with custom config class

    using SolidCubes.WebUtils;

    var conf = new WebBrowserConfig();
	conf.StarUrl = StartUrl;
	conf.Modal = Modal;
	conf.DomainConstraint = DomainConstraint.ToList();

	WebBrowser.Open(conf);