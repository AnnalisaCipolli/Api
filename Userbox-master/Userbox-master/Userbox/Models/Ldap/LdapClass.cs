namespace Userbox.Models.Ldap
{
    public class UnipiADEntry
    {

        public string uid { get; set; } // Equivalent to "samaccountname" and "cn". All these 3 attributes contain the same value.

        public string? givenName { get; set; }

        public string? sn { get; set; }

        public string? displayName { get; set; } // Equivalent to "cn" of LDAP

        public string? title { get; }

        public string? department { get; }

        public string? mail { get; }

        public string? pwdLastSet { get; }

 
    }
}