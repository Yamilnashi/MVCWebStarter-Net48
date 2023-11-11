using System.ComponentModel;

namespace WebMvc.Data
{
    public enum EAppSettings : byte
    {
        [Description("CompanyName")] COMPANY_NAME,
        [Description("Environment")] ENVIRONMENT
    }
}