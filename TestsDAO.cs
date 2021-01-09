using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlProject
{
    class TestsDAO
    {
        private static readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string m_conn_string = @"Data Source=C:\\Users\\Sagi\\.dotnet\\misrad.db;Version=3;";
        public List<Tests> CarsByTests = new List<Tests>();
        public void GetTestsWithCars(int tstid)
        {
                    
            using (SqlCommand cmd = new SqlCommand())
            {
                using (cmd.Connection = new SqlConnection(m_conn_string))
                {
                    Tests result;
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"SELECT Cars.ID, Cars.Manufacturer, Cars.Model, Cars.Year" +
                                        "FROM Cars" +
                                        "JOIN Tests ON Cars.ID = Tests.Car_ID; ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = new Tests
                        {
                            ID = (int)reader["ID"],
                            Car_id = (int)reader["Car_id"],
                            Is_passed = (int)reader["Is_passed"],

                        };
                        CarsByTests.Add(result);
                    }
                    my_logger.Info($"Got All Tests");
                }
            }
        }
    }
}
