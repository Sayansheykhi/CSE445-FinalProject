using System;

namespace PhoenixMembershipPortal.Services
{
    public class QuoteService : IQuoteService
    {
        public string GetQuote(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "friend";
            }

            return $"Hello, {name}! This is your generic quote from the Utility Demo web service.";
        }
    }
}

