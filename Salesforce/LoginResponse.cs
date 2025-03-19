using System.Xml.Serialization;

namespace Salesforce;

[XmlRoot(Namespace = "urn:partner.soap.sforce.com", ElementName = "result", IsNullable = true)]
public sealed class LoginResponse
{
    [XmlElement(ElementName = "metadataServerUrl")]
    public string? MetadataServerUrl;

    [XmlElement(ElementName = "passwordExpired")]
    public bool PasswordExpired;

    [XmlElement(ElementName = "sandbox")]
    public bool Sandbox;

    [XmlElement(ElementName = "serverUrl")]
    public string? ServerUrl;

    [XmlElement(ElementName = "sessionId")]
    public string? SessionId;

    [XmlElement(ElementName = "userId")]
    public string? UserId;
}