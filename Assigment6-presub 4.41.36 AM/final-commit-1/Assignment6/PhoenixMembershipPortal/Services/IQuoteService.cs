using System.ServiceModel;

namespace PhoenixMembershipPortal.Services
{
    [ServiceContract]
    public interface IQuoteService
    {
        [OperationContract]
        string GetQuote(string name);
    }
}

