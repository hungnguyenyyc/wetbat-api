using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace wetbat_api.Repositories
{
    public class TravellerTableDataGateway : AbstratTableDataGateway
    {
        public DataTable GetTravellers() {
            DataTable data = new DataTable();
            try 
            { 
                using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(this.GetSelectAllTravellersQuery(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            data.Load(reader);
                        }
                    }                    
                }
                return data;
            }
            catch (SqlException e)
            {
                //TODO log it somewhere
                Console.WriteLine(e.ToString());
                return data;
            }
        }

        private String GetSelectAllTravellersQuery() {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, UserId, IsResponsibleParty ");
            sb.Append("FROM [dbo].[Travellers]");
            return sb.ToString();
        }
    }
}