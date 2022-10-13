using System.Linq;
using System.Threading.Tasks;
using Cubu.Webhooks.Router;

namespace Acme.Webhooks
{
    /// <summary>
    /// This class derives from WebhooksMapBase, and defines the function to run for each handled events. 
    /// Copyright © 2022 Callflow Software Ltd.
    /// </summary>
    public class CubuWebhooksMap : WebhooksMapBase
    {
        public CubuWebhooksMap()
        {

            // Handling the DataTable.Query webhook, used for searching customers (or other data records).
            // This sample code returns two records as the search results
            DataTable.Query(
                x => x.DataTableSlug == "customers", async (input, results, serviceProvider) =>
            {
                await Task.Delay(100); // simulate a trip to the database 

                // Note: you can access request data such as SearchCriteria, PageSize, OrganizationId, via the input parameter
                if (input.Context.UserEmail == "user@acme.com")
                {
                    // Do something
                }
                foreach (var criterion in input.SearchCriteria)
                {
                    // Use the criterion.SearchPhrase, criterion.PartialMatch to search your database
                }

                // Use input.ContinuationToken to find the next results page 
                // and results.WithContinuationToken("...") to return the current page to the client.

                results.AddRecord("12121212")
                    .WithDisplayName("John Doe")
                    .AddTextField("first-name", "John")
                    .AddTextField("last-name", "Doe");

                results.AddRecord("343434")
                    .WithDisplayName("Jane Doe")
                    .AddTextField("first-name", "Jane")
                    .AddTextField("last-name", "Doe");

            });

            // Handling the "DataTable.Fetch" webhook
            // If the requested RemoteRecordId is ""12121212", return the customer record
            DataTable.Fetch(x => x.DataTableSlug == "customers", async (input, results, serviceProvide) =>
            {
                await Task.Delay(100); // simulates a trip to the database 

                if (input.RemoteRecordId == "12121212")
                    results
                        .CreateDataRecord("12121212")
                            .WithDisplayName("John Doe")
                            .AddTextField("personal-id", "87654321")
                            .AddTextField("first-name", "John")
                            .AddTextField("last-name", "Doe");

                else
                    results
                        .NotFound();

            });

            // Handling the "DataTable.Find" webhook
            DataTable.Find(x =>
                x.DataTableSlug == "contacts" && x.KeyFieldSlug == "personal-id",
                async (input, results, serviceProvide) =>
            {
                await Task.Delay(100); // simulates a trip to the database 

                if (input.KeyFieldValue == "876543210")
                    results
                        .CreateDataRecord("876543210")
                            .WithDisplayName("Johnny Depp")
                            .AddTextField("personal-id", "876543210")
                            .AddTextField("first-name", "Johnny")
                            .AddTextField("last-name", "Depp")
                            .AddPhoneNumberField("mobile-number", "IL", "+972547239688");
            });
        }
    }
}
