using System.ComponentModel;

namespace WebMvc.Data
{
    public enum EAppSettings : byte
    {
        [Description("DepartmentName")] DEPARTMENT_NAME,
        [Description("Environment")] ENVIRONMENT
    }
}