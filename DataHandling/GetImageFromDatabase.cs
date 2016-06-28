using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EMInterfaces;

namespace DataHandling
{
    public class GetImageFromDatabase
    {
        public IImageData GetLastImageWithValidElectricityNumber()
        {
            //Open database and get Image
         
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var cn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                cn.Open();
                //Person person = new Person { FirstName = "Foo", LastName = "Bar", Active = true, DateCreated = DateTime.Now };
                //int id = cn.Insert(person);
                var result = cn.Query<ImageData>("Select top 1 * from ElectricityData where [HasAcceptedElectricityValue]=1 order by FileCreatedDateTime desc").FirstOrDefault();
                cn.Close();
                
                return result;
            }
        }

        public IImageData GetImageById(int id)
        {
            //Open database and get Image

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var cn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                cn.Open();
                //Person person = new Person { FirstName = "Foo", LastName = "Bar", Active = true, DateCreated = DateTime.Now };
                //int id = cn.Insert(person);
                var result = cn.Query<ImageData>("Select * from ElectricityData where id="+id).FirstOrDefault();
                cn.Close();

                return result;
            }
        }


    }
}
