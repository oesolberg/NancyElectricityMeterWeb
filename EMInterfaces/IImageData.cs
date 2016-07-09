using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMInterfaces
{
    public interface IImageData
    {
        int Id { get; set; }

        int? PreviousId { get; set; }

        int ElectricityValue { get; set; }

        int ElectricityValueSetByUser { get; set; }

        string OriginalFilename { get; set; }

        DateTime FileCreatedDateTime { get; set; }

        DateTime CreatedDateTime { get; set; }

        DateTime ChangedDateTime { get; set; }

        byte[] JpgImageOfFrame { get; set; }

        //byte[] JpgImageOfFrameWithDigitsOutlined { get; set; }
        byte[] JpgImageOfFrameWithOutlines { get; set; }

        bool HasAcceptedElectricityValue { get; set; }


    }
}
