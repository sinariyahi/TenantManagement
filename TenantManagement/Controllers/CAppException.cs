using System.Globalization;

namespace TenantManagement.Controllers
{
    public class CAppException : Exception
    {
        public CAppException() : base() { }

        public CAppException(string message) : base(message) { }

        public CAppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
