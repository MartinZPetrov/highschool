using highschool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace highschool.DAL
{
    public class DisciplineDAL
    {
        public static List<Discipline> GetDisciplines(string orderField = null, bool asc = false)
        {
            // create empty list which we'll populate width persons
            List<Discipline> disciplines = new List<Discipline>();

            // use ConfigurationManager class to read connection string from Web.config file
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create new SQLConnection Object
            using (SqlConnection con = new SqlConnection(CS))
            {
                //Create new SqlCommand object.
                SqlCommand cmd = null;
                if (!string.IsNullOrEmpty(orderField))
                {
                    cmd = new SqlCommand("Select * from Disciplines ORDER BY " + orderField + (asc ? " ASC" : " DESC"), con);
                }
                else
                {
                    cmd = new SqlCommand("Select * from Disciplines", con);
                }
                con.Open();

                // Create new SqlDataReader object by invoking ExecuteReader method.
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // as long as there are more records to read Read == true
                    while (rdr.Read())
                    {
                        Discipline d = new Discipline();
                        d.DisciplineId = Convert.ToInt32(rdr["DisciplineId"]);
                        d.DisciplineName = rdr["DisciplineName"].ToString();
                        d.ProfessorName = rdr["ProfessorName"].ToString();
                        // populate list
                        disciplines.Add(d);
                    }
                }
            }
            return disciplines;
        }
        public static Discipline GetDiscipline(int dID)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from Disciplines where DisciplineId=@DisciplineId", con);
                cmd.Parameters.Add(new SqlParameter("@DisciplineId", dID));
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    Discipline d = new Discipline();
                    d.DisciplineId = Convert.ToInt32(rdr["DisciplineId"]);
                    d.DisciplineName = rdr["DisciplineName"].ToString();
                    d.ProfessorName = rdr["ProfessorName"].ToString();
                    return d;
                }
            }
        }
        public static void UpdateDiscipline(Discipline d)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Update Disciplines set DisciplineName=@DisciplineName, ProfessorName=@ProfessorName," +
                                                "where DisciplineId=@DisciplineId", con);
                cmd.Parameters.Add(new SqlParameter("@DisciplineId", d.DisciplineId));
                cmd.Parameters.Add(new SqlParameter("@DisciplineName", d.DisciplineName));
                cmd.Parameters.Add(new SqlParameter("@ProfessorName", d.ProfessorName));
               
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        // Insert person method
        public static void InsertDiscipline(Discipline d)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Insert into Discipline (DisciplineName, ProfessorName) values (@DisciplineName, @ProfessorName)", con);
                cmd.Parameters.Add(new SqlParameter("@DisciplineName", d.DisciplineName));
                cmd.Parameters.Add(new SqlParameter("@ProfessorName", d.ProfessorName));
                con.Open();
                var n = cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete person BY param
        /// </summary>
        /// <param name="dID"></param>
        public static void DeleteDiscipline(int dID)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Delete from Disciplines where DisciplineId=@DisciplineId", con);
                cmd.Parameters.Add(new SqlParameter("@DisciplineId", dID));
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}