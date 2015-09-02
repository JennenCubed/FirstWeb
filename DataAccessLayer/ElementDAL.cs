using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccessLayer
{
    public class ElementDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public IEnumerable<Element> elements
        {
            get
            {
                List<Element> elements = new List<Element>();

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("getElements", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        Element E = new Element();

                        E.ID = Convert.ToInt32(rdr["ID"]);
                        E.Name = rdr["Name"].ToString();

                        elements.Add(E);
                    }
                }
                return elements;
            }
        }
    }
}
