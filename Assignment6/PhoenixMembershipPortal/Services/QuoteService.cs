using System;

namespace PhoenixMembershipPortal.Services
{
    /// <summary>
    /// WCF service implementation for generating personalized quotes.
    /// Provides a simple quote generation service for demonstration purposes.
    /// </summary>
    public class QuoteService : IQuoteService
    {
        /// <summary>
        /// Generates a personalized quote message for the specified name.
        /// If the name is null or whitespace, defaults to "friend".
        /// </summary>
        /// <param name="name">The name to personalize the quote with. Can be null or empty.</param>
        /// <returns>A formatted quote string personalized with the provided name</returns>
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

