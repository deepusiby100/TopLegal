using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace top.legal
{
    class CRUDoperations
    {
        public void PerformCRUD(IOrganizationService svc)
        {
            //CREATE
            var toplegalAccount = new Entity("account");
            toplegalAccount.Attributes["name"] = "Top.Legal";
            toplegalAccount.Attributes["websiteurl"] = "top.legal";
            Guid accountID = svc.Create(toplegalAccount);
            Console.WriteLine("Account created with ID - " + accountID);

            //RETRIEVE  
            Entity retrievedAccount = svc.Retrieve("account", accountID, new ColumnSet("name", "websiteurl"));
            Console.WriteLine("Account name retrieved is - " + retrievedAccount.Attributes["name"]);

            //UPDATE
            Entity myAccount = new Entity("account");
            myAccount.Id = accountID;
            myAccount.Attributes["name"] = "Top.Legal Consultants";
            svc.Update(myAccount);
            Console.WriteLine("Account name updated as " + myAccount.Attributes["name"]);


            //DELETE
            svc.Delete("account", accountID);
            Console.WriteLine("Account-" + myAccount.Attributes["name"] + " deleted");
        }
    }
}
