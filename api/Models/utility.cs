namespace api.Models
{
    public static class utility
    {


        public static RootExport GetMUD(Root json)
        {
            RootExport re= new RootExport();
            JsonMUDExport res = new JsonMUDExport();

            if (json != null )
            {
                res.student = new List<StudentExport>();

                if (json.list.student != null)
                {
                    foreach (Student s in json.list.student)
                    {
                        StudentExport se = new StudentExport();

                        se.cognome = s.COGNOME;
                        se.nome = s.NOME;
                        se.stu_attivo = s.STU_ATTIVO;
                        se.user_name = s.USER_NAME;
                        se.user_id = s.USER_ID;
                        se.grp_id = s.GRP_ID;
                        se.cod_fis = s.COD_FIS;
                        se.email = s.COD_FIS;
                        se.matricola = s.MATRICOLA;



                        res.student.Add(se);
                    }
                }
            }
            else
            {
                res.student = new List<StudentExport>();
            }

            re.list = res;

            return re;
        }
    }
}
