using System;

namespace WebMvc.ViewModels.Profile
{
    public class MyProfileIndexViewModel
    {
        public Guid UserGuid { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string ManagerName { get; set; }
        public string Title { get; set; }
        public string Division { get; set; }
        public string Branch { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}