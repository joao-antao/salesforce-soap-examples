using System.Text;

namespace Salesforce;

internal sealed class QueryHttpContent(string sessionId, string queryString) : StringContent(GetQueryXmlContent(sessionId, queryString), Encoding.UTF8, "text/xml")
{
    private static string GetQueryXmlContent(string sessionId, string queryString)
    {
        return $@"
        <soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:urn='urn:partner.soap.sforce.com'>
            <soapenv:Header>
                <urn:SessionHeader>
                    <urn:sessionId>{sessionId}</urn:sessionId>
                </urn:SessionHeader>
            </soapenv:Header>
            <soapenv:Body>
                <urn:query>
                    <urn:queryString>{queryString}</urn:queryString>
                </urn:query>
            </soapenv:Body>
        </soapenv:Envelope>";
    }
}