using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace StudentRESTWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together...
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        #region Connection string
        //Data Source=natascha.database.windows.net;Initial Catalog=School;Integrated Security=False;User ID=nataschajakobsen;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private static string connectingString =
               "Server=tcp:natascha.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=nataschajakobsen;Password=Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        #endregion

        #region POST
        public Student AddLys(Student elev)
        {
            const string postStudent = "insert into Student (Name, Age) values (@Name, @Age)";

            using (SqlConnection conn = new SqlConnection(connectingString))
            {

                conn.Open();
                using (SqlCommand insertCommand = new SqlCommand(postStudent, conn))
                {
                    insertCommand.Parameters.AddWithValue("@Name", elev);
                    insertCommand.Parameters.AddWithValue("@Age", elev);
                    
                    
                }
            }

            return elev;

        }
        #endregion

        #region Create fail
        public void CreateAparment(string elev)
        {

            //const string postStudent = "insert into Student (Name) values (@Name)";
            //using (SqlConnection conn = new SqlConnection(connectingString))
            //{
            //    conn.Open();
            //    using (SqlCommand insertCommand = new SqlCommand(postStudent, conn))
            //    {
            //        insertCommand.Parameters.AddWithValue("@Name", elev);

            //        int rowsAffected = insertCommand.ExecuteNonQuery();
            //        return rowsAffected;

            //    }
            //}

            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                using (SqlCommand insertCommand = new SqlCommand($"insert into Student(Name) values (@Name", conn))
                {
                    insertCommand.Parameters.AddWithValue("@NameOfList", elev);
                    insertCommand.ExecuteNonQuery();
                }
            }

            //string sqlstring = $"INSERT INTO Apartment VALUES {elev.Id}, {elev.Name}, {elev.Age}";
            //using (SqlConnection conn = new SqlConnection(connectingString))
            //{
            //    conn.Open();
            //    using (var sqlcmd = new SqlCommand(sqlstring, conn))
            //    {
            //        SqlDataReader reader = sqlcmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            //Student nystudent = new Student();

            //            //nystudent.Id = reader.GetInt32(0);
            //            //nystudent.Name = reader.GetString(1);
            //            //nystudent.Age = reader.GetInt32(2);




            //        }
            //    }


            //}

            //using (SqlConnection conn = new SqlConnection(connectingString))
            //{
            //    conn.Open();
            //    using (SqlCommand insertCommand = new SqlCommand($"insert into Student(elev) values (@Name, @Age)", conn))
            //    {
            //        insertCommand.Parameters.AddWithValue("@Name", elev);
            //        insertCommand.Parameters.AddWithValue("@Age", elev);
            //        insertCommand.ExecuteNonQuery();
            //    }
            //}

            //        SqlDataReader reader = sqlcmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            Student nystudent = new Student();

            //            nystudent.Id = reader.GetInt32(0);
            //            nystudent.Name = reader.GetString(1);
            //            nystudent.Age = reader.GetInt32(2);



            //            .Add(newapartment);
            //        }

            //    }
            //}

        }
        #endregion 

        #region READ HTTP (GET kald)
        public IList<Student> GetAllStudents()
        {
            const string sqlstring = "SELECT * from dbo.Student order by id";
            List<Student> liste = new List<Student>();


            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                //using (var sqlCommand = new SqlCommand(sqlstring, conn))
                //{
                //    using (var reader = sqlCommand.ExecuteReader())
                //    {
                //        List<Student> liste = new List<Student>();
                //        while (reader.Read())
                //        {
                //            var _Apartment = ReadApartment(reader);
                //            liste.Add(_Apartment);
                //        }
                //        return liste;
                //    }
                //}

                SqlCommand command = new SqlCommand(sqlstring, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student nystudent = new Student();

                    nystudent.Id = reader.GetInt32(0);
                    nystudent.Name = reader.GetString(1);
                    nystudent.Age = reader.GetInt32(2);

                    liste.Add(nystudent);
                }
                
            }
            return liste;
        }
        #endregion


        #region PUT (UPDATE)
        public void UpdateApartment(string id, Student age)
        {
            //using (SqlConnection conn = new SqlConnection(connectingString))
            //{

            //    conn.Open();
            //    using (SqlCommand insertCommand = new SqlCommand($"update Student set Age = @Age WHERE Id = @Id", conn))
            //    {
            //        insertCommand.Parameters.AddWithValue("@Age", age);
                    
            //        insertCommand.ExecuteNonQuery();

            //    }
            //}

            string sqlstring = $"UPDATE Student SET Age = {age.Age}";
            using (SqlConnection sqlConnection = new SqlConnection(connectingString))
            {
                sqlConnection.Open();
                using (var sqlcommand = new SqlCommand(sqlstring, sqlConnection))
                {
                    SqlDataReader reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {

                    }

                }
            }
        }
        #endregion

        #region DELETE
        public void Deleteaparment(string studentid)
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                using (SqlCommand insertCommand = new SqlCommand($"DELETE FROM Student WHERE Id = @Id", conn))
                {
                    insertCommand.Parameters.AddWithValue("@Id", studentid);
                    insertCommand.ExecuteNonQuery();
                }
            }

           
        }
        #endregion

    }
}
