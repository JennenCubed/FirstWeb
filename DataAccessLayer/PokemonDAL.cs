using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class PokemonDAL
    {
        private string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        public IEnumerable<Pokemon> pokemon
        {
            get
            {
                List<Pokemon> pokemon = new List<Pokemon>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("getPokemon", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        Pokemon P = new Pokemon();

                        P.Name = rdr["Name"].ToString();
                        P.Type = rdr["Type"].ToString();
                        P.HP = Convert.ToInt32(rdr["HP"]);
                        P.Attack = Convert.ToInt32(rdr["Attack"]);
                        P.Defense = Convert.ToInt32(rdr["Defense"]);
                        P.SpecialAttack = Convert.ToInt32(rdr["SpecialAttack"]);
                        P.SpecialDefense = Convert.ToInt32(rdr["SpecialDefense"]);
                        P.Speed = Convert.ToInt32(rdr["Speed"]);

                        pokemon.Add(P);
                    }
                }
                return pokemon;
            }
        }

        public void addPokemon(Pokemon P) { }

    }
}
