using System.ServiceModel;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Service contract interface for the MembershipService WCF service.
    /// Defines operations for membership-related functionality.
    /// </summary>
    [ServiceContract]
    public interface IMembershipService
    {
        /// <summary>
        /// Checks if a username is available (not already taken) in the system.
        /// </summary>
        /// <param name="username">The username to check for availability</param>
        /// <returns>True if the username already exists (not available), false if available</returns>
        [OperationContract]
        bool CheckUsernameAvailability(string username);
    }
}
