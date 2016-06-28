using Nancy;

namespace NancyElectricityMeterWeb.Modules
{
    public class ShowStandardImageModule: NancyModule
    {
        public ShowStandardImageModule()
        {
            Get["/standardimage"] = parameters =>
            {
                //var electricityViewModel = GetDataToShowOnWebPage();
                return View["ShowStandardImage"];
            };
        }
    }
}