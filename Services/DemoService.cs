using System;

namespace Acme.Webhooks.Services
{
    public class DemoService : IDemoService
    {
        private readonly string random;

        public DemoService()
        {
            random = Guid.NewGuid().ToString("N");
        }

        public string GetText()
        {
            return $"This is the text from demo service '{random}!";
        }
    }
}