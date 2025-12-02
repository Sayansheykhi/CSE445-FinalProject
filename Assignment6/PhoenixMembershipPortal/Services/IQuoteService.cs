using System.ServiceModel;

namespace PhoenixMembershipPortal.Services
{
    /// <summary>
    /// Service contract interface for the QuoteService WCF service.
    /// Defines operations for generating personalized quotes.
    /// </summary>
    [ServiceContract]
    public interface IQuoteService
    {
        /// <summary>
        /// Generates a personalized quote message for the specified name.
        /// </summary>
        /// <param name="name">The name to personalize the quote with. If empty, uses "friend" as default.</param>
        /// <returns>A personalized quote string message</returns>
        [OperationContract]
        string GetQuote(string name);
    }
}

