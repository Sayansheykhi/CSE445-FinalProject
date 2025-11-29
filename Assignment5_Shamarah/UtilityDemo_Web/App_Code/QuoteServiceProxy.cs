using System;
using System.ServiceModel;

namespace UtilityDemoWeb
{
    //Same contract as server
    [ServiceContract]
    public interface IQuoteService
    {
        [OperationContract]
        string GetQuote(string name);
    }

    public class QuoteServiceProxy
    {
        private readonly string _endpointUrl;

        public QuoteServiceProxy(string endpointUrl)
        {
            _endpointUrl = endpointUrl;
        }

        public string GetQuote(string name)
        {
            var binding = new BasicHttpBinding();
            var address = new EndpointAddress(_endpointUrl);

            ChannelFactory<IQuoteService> factory =
                new ChannelFactory<IQuoteService>(binding, address);

            IQuoteService channel = factory.CreateChannel();

            try
            {
                return channel.GetQuote(name);
            }
            finally
            {
                try
                {
                    ((IClientChannel)channel).Close();
                    factory.Close();
                }
                catch
                {
                    ((IClientChannel)channel).Abort();
                    factory.Abort();
                }
            }
        }
    }
}
