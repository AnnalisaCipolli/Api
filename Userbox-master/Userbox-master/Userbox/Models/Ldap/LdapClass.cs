using System.Runtime.Serialization;

namespace Userbox.Models.Ldap
{
    public class UnipiEntry
    {
       
            public enum ProvisioningSource
            {
                [EnumMember(Value = "self")]
                self,
                [EnumMember(Value = "spid")]
                spid,
                [EnumMember(Value = "cie")]
                cie,
                [EnumMember(Value = "cns")]
                cns,
                [EnumMember(Value = "idunipi")]
                idunipi
            }
            public string uid { get; set; }
            public string? givenName { get; set; }
            public string? sn { get; set; }
            public string? unipiCodiceFiscale { get; set; }
            public string? mail { get; set; }
            public string? unipiExtMail { get; set; }
            public string? mobile { get; set; }
            public ProvisioningSource? unipiProvisioningSource { get; set; }
            public string? pwdLastSet { get; }


            public UnipiEntry()
            {
                this.uid = "";
                this.givenName = "";
                this.sn = "";
                this.unipiCodiceFiscale = "";
                this.mobile = "";
                this.unipiExtMail = "";
                this.unipiProvisioningSource = null;
                this.mail = "";
                this.pwdLastSet = "";
            }

        }

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

            public UnipiADEntry()
            {
                this.uid = "";
                this.givenName = "";
                this.sn = "";
                this.mail = "";
                this.title = "";
                this.department = "";
                this.displayName = "";
                this.pwdLastSet = "";
            }
        }

}