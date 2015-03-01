# WebAPICors
A .NET Web API Custom CORS Attribute with test page

This solution demonstrates how to replace the EnableCors attribute with a custom attribute 
that will read a list of allowed URL's from the web.config.
<br><br>
There are two projects:  the API and the test client.  Both projects are using IISExpress using localhost but on different ports.
<br><br>
In the WebAPI2Cors project you will find a controller named TestController.  The class is decorated
with the custom attribute EnableCorsCustom.
<br>
<h4>EnableCorsCustomAttribute.cs</h4>
This class contains the custom attribute.  It will set the necessary response headers and read the allowed 
URL's from the web.config.
The class could be modified to read the URL's from another source, such as a database.
