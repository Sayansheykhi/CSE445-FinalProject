using System.ServiceModel;

namespace QuoteServiceApp
{
    [ServiceContract]
    public interface IQuoteService
    {
        [OperationContract]
        string GetQuote(string name);
    }
}
