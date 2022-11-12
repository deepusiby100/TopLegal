using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace top.legal
{
    public class OAuthConn
    {
        public static IOrganizationService AADappConnection(string clientId, string clientSecret, string organizationUri)
        {
            CrmServiceClient conn = null;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            string connectionString = "Url=" + organizationUri + "; " +
            "AuthType=ClientSecret; " +
            "ClientId= " + clientId + "; " +
            "ClientSecret=" + clientSecret;
            {
                try
                {
                    conn = new CrmServiceClient(connectionString);
                    return conn.OrganizationWebProxyClient != null ? conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while connecting to CRM " + ex.Message);
                    Console.ReadKey();
                    return null;
                }
            }
        }
    }
}
