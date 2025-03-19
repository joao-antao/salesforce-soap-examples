using System.Xml.Linq;
using System.Xml.Serialization;
using Salesforce;

// DO NOT USE THIS CODE IN ANY PRODUCTION ENVIRONMENT.
const string urn = "urn:partner.soap.sforce.com";
const string username = "YOUR_USERNAME";
const string password = "YOUR_PASSWORD";
const string token = "YOUR_TOKEN";
const string loginUrl = "https://test.salesforce.com/services/Soap/u/63.0";

using var loginContent = new LoginHttpContent(username, password, token);
using var loginRequest = new HttpRequestMessage(HttpMethod.Post, loginUrl);
loginRequest.Content = loginContent;
loginRequest.Headers.Add("SOAPAction", "login");

using var loginResponse = await new HttpClient().SendAsync(loginRequest);
var loginResponseXml = XDocument.Parse(await loginResponse.Content.ReadAsStringAsync())
    .Descendants(XNamespace.Get(urn) + "result").First().ToString();

var serializer = new XmlSerializer(typeof(LoginResponse));
LoginResponse? login;
using (var stringReader = new StringReader(loginResponseXml))
{
    login = (LoginResponse)serializer.Deserialize(stringReader);
}

var soqlQuery = "SELECT Id, Name, Email FROM Contact LIMIT 5";
using var queryContent = new QueryHttpContent(login.SessionId, soqlQuery);
using var queryRequest = new HttpRequestMessage(HttpMethod.Post, login.ServerUrl);
queryRequest.Content = queryContent;
queryRequest.Headers.Add("SOAPAction", "\"\"");

using var queryResponse = await new HttpClient().SendAsync(queryRequest);
if (queryResponse.IsSuccessStatusCode)
{
    // Deserialize your data
}

Console.ReadKey();