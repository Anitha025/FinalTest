using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BShopTest
{
   public class DatabaseConnection
    {
        static string ConConnect = @"Data Source=RILPT172;Initial Catalog=BShop;User ID=sa;Password=sa123";

        public void AddDress(Dresses dresses)
        {
            using (SqlConnection con = new SqlConnection(ConConnect))
            {
                string query = "INSERT INTO DressCollections VALUES(@DID,@DType,@DFabric,@DPrice)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", dresses.Did);
                cmd.Parameters.AddWithValue("@name", dresses.Dtype);
                cmd.Parameters.AddWithValue("@actor", dresses.Dfabric);
                cmd.Parameters.AddWithValue("@actress", dresses.Dprice);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("Details not added...!");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public List<Dresses> GetDresses()
        {
            var list = new List<Dresses>();
            using (SqlConnection con = new SqlConnection(ConConnect))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM DressCollections";
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var dresses = new Dresses();
                        reader.Read();
                        dresses.Did = Convert.ToInt32(reader[0]);
                        dresses.Dtype = reader[1].ToString();
                        dresses.Dfabric = reader[2].ToString();
                        dresses.Dprice = Convert.ToInt32(reader[3]);
                    }
                    else
                        throw new Exception("Dress not find'''!");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return list;
            }
  
        }
        public void UpdateDress(Dresses dresses)
        {
            using (SqlConnection con = new SqlConnection(ConConnect))
            {
                var query = $"UPDATE DressCollections set DID = '{ dresses.Did }', DType = '{dresses.Dtype}', DFabric = '{dresses.Dfabric}' where DID = {dresses.Did}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Details were updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void DeleteDress(int id)
        {
            Dresses dresses = new Dresses();
            using (SqlConnection con = new SqlConnection(ConConnect))
            {

                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM DressCollections WHERE DID = " + id;
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 0)
                        throw new Exception("Connot delete the selected Dress...!");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}
