using System.IO;
using System.Linq;
using DataHandling;
using Nancy;

namespace NancyElectricityMeterWeb.Modules
{
    public class ImageHandlerModule : NancyModule
    {
        public ImageHandlerModule()
        {

            Get["/image/{ImageID}"] = parameters =>
            {
                string contentType = "image/jpg";
                var byteArray = GetImageById(parameters.ImageId);
                //return FromByteArray(byteArray, contentType);
                return new ByteArrayResponse(byteArray, contentType);
               // Response.FromByteArray(byteArray, contentType);
            };
        }

        private byte[] GetImageById(int imageId)
        {
            var dbOp = new DataHandling.GetImageFromDatabase();
            var imageData = dbOp.GetImageById(imageId);
            if(imageData.JpgImageOfFrameWithOutlines!=null)
                return imageData.JpgImageOfFrameWithOutlines;
            return imageData?.JpgImageOfFrame;
        }
    }

}