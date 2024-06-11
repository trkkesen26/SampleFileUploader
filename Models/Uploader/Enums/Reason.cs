using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFileUploader.Models.Uploader.Enums
{
    public enum Reason
    {
        RSN_NONE,
        RSN_JSON_INVALID,
        RSN_BASE64,
        RSN_SD_ERR,
        RSN_PACKED_ERR,
        RSN_CRC_ERR,
        RSN_RECV_ERR,
        RSN_NO_DATA
    }
}
