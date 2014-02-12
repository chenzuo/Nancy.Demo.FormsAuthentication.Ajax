Nancy.Demo.FormsAuthentication.Ajax
===================================

Live demo: http://nancyajax.nathanchere.com.au/


Overview
-----

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

Disclaimer
----------
This demo is intentionally very narrow in scope and is not intended to demonstrate best practices of any kind.

That said, feel free to pass along your "doing it wrong" and "stfu n00b" feedback:

[Tweet to @nathanchere](https://twitter.com/intent/tweet?screen_name=nathanchere&text=Your%20code%20sucks)

[Follow @nathanchere](https://twitter.com/nathanchere)            

Better yet, feel free to [fork the demo project](https://github.com/ferretallica/Nancy.Demo.FormsAuthentication.Ajax/fork)
and demonstrate how it can be done better.

[![Build status](https://ci.appveyor.com/api/projects/status?id=6shtlnnwqnnivl0p)](https://ci.appveyor.com/project/nancy-demo-formsauthentication-ajax)