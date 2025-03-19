using System.Text;

namespace Salesforce;

internal sealed class LoginHttpContent(string username, string password, string token) : StringContent(GetLoginXmlContent(username, password, token), Encoding.UTF8, "text/xml")
{
    private static string GetLoginXmlContent(string username, string password, string token)
    {
        return $@"
        <soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:urn='urn:partner.soap.sforce.com'>
            <soapenv:Header/>
            <soapenv:Body>
                <urn:login>
                    <urn:username>{username}</urn:username>
                    <urn:password>{password + token}</urn:password>
                </urn:login>
            </soapenv:Body>
        </soapenv:Envelope>";
    }
}