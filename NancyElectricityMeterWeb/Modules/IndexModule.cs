using System;
using Nancy;

namespace NancyElectricityMeterWeb.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                var electricityViewModel = GetDataToShowOnWebPage();
                return View["index", electricityViewModel];
            };
        }

        private ElectricityViewModel GetDataToShowOnWebPage()
        {
            var vm = new ElectricityViewModel();
            var dbOp = new DataHandling.GetImageFromDatabase();
            var imageData = dbOp.GetImage(null,true);
           
            
            vm.ImageNotOutlinedSrc = $"data:image/gif;base64,{Convert.ToBase64String(imageData.JpgImageOfFrame)}";
            vm.Id = imageData.Id;
            vm.ElectricityNumber = imageData.ElectricityValue;
            vm.IsValidNumber = imageData.HasAcceptedElectricityValue;
            vm.ImageOutlinedSrc  = $"data:image/gif;base64,{Convert.ToBase64String(imageData.JpgImageOfFrameWithOutlines)}";
            vm.FileCreatedDateTimeString = imageData.FileCreatedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return vm;
        }
    }

    internal class ElectricityViewModel
    {
        public int Id { get; set; }

        public int? PreviousId { get; set; }
        public int ElectricityNumber { get; set; }
        public string ImageNotOutlinedSrc { get; set; }
        public string ImageOutlinedSrc { get; set; }

        public DateTime FileCreatedDateTime { get; set; }

        public bool IsValidNumber { get; set; }
        public string FileCreatedDateTimeString { get; set; }
    }
}