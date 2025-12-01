using System.ServiceModel;

namespace PhoenixMembershipPortal
{
    [ServiceContract]
    public interface IMembershipService
    {
        [OperationContract]
        bool CheckUsernameAvailability(string username);
    }
}
