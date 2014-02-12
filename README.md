Nancy.Demo.FormsAuthentication.Ajax
===================================

This demo is intended to supplement the official Nancy FormsAuthentication documentation which assumes that the result of Login() and its variants will be returned to the client as-is. This is not ideal in a scenario where you want to use an AJAX call to handle authentication instead of a normal form submit (e.g. "SPA" sites).

The crux of this demo lies is the Javascript in "~/Views/index.cshtml" which uses the jQuery
cookies plugin to set the "_ncfa" cookie which Nancy uses for managing sessions. This cookie should contain an encoded and encrypted GUID representing the currently logged in user for the authenticated session to be valid.

**In short**
-----------

From a NancyModule use

**this.LoginWithoutRedirect(guid).Cookies[0].Value**

to get the encrypted authentication token, then on the client use

**$.cookie('_ncfa', authToken)**

to store that token so that future requests will recognise the authenticated user.
