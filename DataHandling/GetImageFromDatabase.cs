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
        private string _connectionString;

        public GetImageFromDatabase()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IImageData GetImage(int? imageId, bool needValidNumber = false)
        {
            var foundImage = GetImageById(imageId, needValidNumber);
            if(foundImage!=null)
                foundImage.PreviousId = GetPreviousId(foundImage.Id);
            return foundImage;
        }
        private IImageData GetImageById(int? id, bool needValidNumber)
        {
            string imageQuery = "Select top 1 * from ElectricityData order by Id desc";
            //Open database and get Image
            if (!needValidNumber && (!id.HasValue || id.Value < 1))
            {
                imageQuery = "Select top 1 * from ElectricityData order by Id desc";
            }
            else if (needValidNumber && (!id.HasValue || id.Value < 1))
            {
                imageQuery = "Select top 1 * from ElectricityData where [HasAcceptedElectricityValue]=1 order by Id desc";
            }
            else if (!needValidNumber && id.HasValue && id.Value > 0)
            {
                imageQuery = "Select  * from ElectricityData where Id="+id.Value;
            }
            else if (needValidNumber && id.HasValue && id.Value > 0)
            {
                imageQuery = "Select  * from ElectricityData [HasAcceptedElectricityValue]=1 and Id=" + id.Value + " order by Id desc";
            }


            using (var cn = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                cn.Open();

                var result = cn.Query<ImageData>(imageQuery).FirstOrDefault();
                cn.Close();
                return result;
            }
        }

        private int? GetPreviousId(int currentId)
        {
            if (currentId > 0)
                using (var cn = new System.Data.SqlClient.SqlConnection(_connectionString))
                {
                    cn.Open();

                    var result = cn.Query<int>("Select top 1 Id from ElectricityData where Id<" + currentId + " order by Id desc").FirstOrDefault();
                    cn.Close();

                    return result;
                }
            return null;
        }



    }
}
