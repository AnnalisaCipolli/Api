namespace Userbox.Models
{
    public class AuthenticatedUserInfo
    {
        public string principal { get; set; }
        public string sub { get; set; }
        public string credential { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string fiscalNumber { get; set; }
        public string email { get; set; }
    }
}