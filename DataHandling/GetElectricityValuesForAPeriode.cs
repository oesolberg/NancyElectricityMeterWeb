using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EMInterfaces;

namespace DataHandling
{
    public class GetElectricityValuesForAPeriode : IGetElectricityValuesForAPeriode
    {
        private readonly string _connectionString;

        public GetElectricityValuesForAPeriode()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<int> GetElectricityValuesForGivenPeriode(DateTime startDateTime, DateTime endDateTime)
        {

            using (var cn = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                cn.Open();

                var result = cn.Query<int>("Select [ElectricityValue] from [ElectricityData] where [HasAcceptedElectricityValue]=1 and [FileCreatedDateTime]>='" 
                    + startDateTime.ToString("s") + "' and [FileCreatedDateTime]<='" + endDateTime.ToString("s") + "' order by [FileCreatedDateTime] ");
                cn.Close();
                return result.ToList();
            }

        }

      

    }
}