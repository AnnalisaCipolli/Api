namespace api.Models
{
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
