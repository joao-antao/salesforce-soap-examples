using System.Xml.Linq;
using Salesforce;

// DO NOT USE THIS CODE IN ANY PRODUCTION ENVIRONMENT.
const string urn = "urn:partner.soap.sforce.com";
const string username = "YOUR_USERNAME";
const string password = "YOUR_PASSWORD";
const string token = "YOUR_TOKEN";
const string loginUrl = "https://test.salesforce.com/services/Soap/u/63.0";

var loginContent = new LoginHttpContent(username, password, token);
var loginRequest = new HttpRequestMessage(HttpMethod.Post, loginUrl)
{
    Content = loginContent,
    Headers = { { "SOAPAction", "login" } }
};

var loginResponse = await new HttpClient().SendAsync(loginRequest);
var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
var loginResponseXml = XDocument.Parse(loginResponseContent);
var login = new LoginResponse(loginResponseXml.Descendants(XName.Get("serverUrl", "urn:partner.soap.sforce.com")).FirstOrDefault()?.Value, 
    loginResponseXml.Descendants(XName.Get("sessionId", "urn:partner.soap.sforce.com")).FirstOrDefault()?.Value);

var soqlQuery = "SELECT Id, Name, Email FROM Contact LIMIT 5";
var queryContent = new QueryHttpContent(login.SessionId, soqlQuery);
var queryRequest = new HttpRequestMessage(HttpMethod.Post, login.ServerUrl)
{
    Content = queryContent,
    Headers = { { "SOAPAction", "\"\"" } }
};
var queryResponse = await new HttpClient().SendAsync(queryRequest);
if (queryResponse.IsSuccessStatusCode)
{
    // Deserialize your data
}

Console.ReadKey();