using Dependency_Injection.Enum;
namespace Dependency_Injection.Exception_Handler
{
    public class User_Defined_Exception
    {
        public string NotFoundException()
        {
            exceptions exc =(exceptions)1003; //exception enum defined in ExceptionCodes.cs inside Enum folder.
            return $"1003:{exc}";
        }
        public string InternalServerError()
        {
            exceptions exc = (exceptions)1001;
            return $"1001:{exc}";
        }
        public string Ok()
        {
            exceptions exc=(exceptions)1005;
            return $"1005:{exc}";
        }
        public string BadGatewayException()
        {
            exceptions exc = (exceptions)1007;
            return $"1007:{exc}";
        }
        public string UnAuthorizeException()
        {
            exceptions exc = (exceptions)1010;
            return $"1010:{exc}";
        }
        public string ForbiddenException()
        {
            exceptions exc = (exceptions)1020;
            return $"1020:{exc}";
        }
    }
}
