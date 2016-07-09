using System;
using System.IO;
using System.Linq;
using DataHandling;
using Nancy;

namespace NancyElectricityMeterWeb.Modules
{
    public class ShowImageModule : NancyModule
    {
        public ShowImageModule()
        {

            Get["/showimage/{ImageID?}"] = parameters =>
            {
                var electricityViewModel = GetDataToShowOnWebPage(parameters.ImageId);
                return View["showimage", electricityViewModel];
            };
        }

        private ElectricityViewModel GetDataToShowOnWebPage(int? imageId)
        {
            var vm = new ElectricityViewModel();
            var dbOp = new DataHandling.GetImageFromDatabase();
            var imageData = dbOp.GetImage(imageId);

            vm.PreviousId = imageData.PreviousId;
            vm.ImageNotOutlinedSrc = $"data:image/gif;base64,{Convert.ToBase64String(imageData.JpgImageOfFrame)}";
            vm.Id = imageData.Id;
            vm.ElectricityNumber = imageData.ElectricityValue;
            vm.IsValidNumber = imageData.HasAcceptedElectricityValue;
            vm.ImageOutlinedSrc = $"data:image/gif;base64,{Convert.ToBase64String(imageData.JpgImageOfFrameWithOutlines)}";
            vm.FileCreatedDateTimeString = imageData.FileCreatedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return vm;
        }
    }

}