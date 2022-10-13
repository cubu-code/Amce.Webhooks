using System;
using Acme.Webhooks.Services;

namespace Acme.Webhooks
{
    public class DataWebhooks
    {
        private IServiceProvider serviceProvider;
        private readonly IDemoService demoService;

        public DataWebhooks(IServiceProvider serviceProvider)
        {

            this.demoService = (IDemoService)serviceProvider.GetService(typeof(IDemoService));
            this.serviceProvider = serviceProvider;
        }


        // public async Task HandleNewProductAsync(
        //     BeforeCreatedData data,
        //     BeforeCreatedResultsBuilder results)
        // {
        //     var slug = "product-name";
        //     var f = data.Fields.SingleOrDefault(x => x.Slug == slug);

        //     if (f != null)
        //     {
        //         var productName = TextField.FromData(f.JsonData);
        //         results.SetTextField(slug, productName.Text + "+ my 2 cents");
        //     }
        //     else
        //     {
        //         results.SetTextField(slug, "New value from hook");
        //     }

        //     results.AddMessage(AgentMessageType.Warning, "Added my 2 cents...");

        //     await Task.Delay(10);
        // }

    }
}