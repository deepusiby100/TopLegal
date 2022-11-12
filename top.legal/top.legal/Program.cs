using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace top.legal
{
    class Program : OAuthConn
    {
        static void Main(string[] args)
        {
            CRUDoperations CRUD = new CRUDoperations();
            IOrganizationService svc = AADappConnection("2f388ee8-6fa8-46bf-906d-e603ace90d84",
                                                        "3KV8Q~G1VfcdvmdfXkOk-v32ePQ2cCqhnwIwVde8",
                                                        "https://toplegal.crm4.dynamics.com/");
            var response = svc.Execute(new WhoAmIRequest());
            CRUD.PerformCRUD(svc);
        }
    }
}
