namespace api.Models
{
    /*export*/
    

    public class JsonMUDExport
    {
        public List<StudentExport> student { get; set; }
    }

    public class RootExport
    {
        public JsonMUDExport list { get; set; }
    }

    public class StudentExport
    {
        public string cod_fis { get; set; }
        public int grp_id { get; set; }
        public string stu_attivo { get; set; }
        public string matricola { get; set; }
        public string cognome { get; set; }
        public object user_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
    }



    /*import*/

    public class JsonMUD
    {
        public List<Student> student { get; set; }
    }

    public class Root
    { 
        public JsonMUD list { get; set; }
    }

    public class Student
    {
        public string COD_FIS { get; set; }
        public int GRP_ID { get; set; }
        public string STU_ATTIVO { get; set; }
        public string MATRICOLA { get; set; }
        public string COGNOME { get; set; }
        public object USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string EMAIL { get; set; }
        public string NOME { get; set; }
    }

}
