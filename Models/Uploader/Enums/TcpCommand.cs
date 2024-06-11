using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFileUploader.Models.Uploader.Enums
{
    public enum TcpCommand
    {
        TCP_CMD_ERR = -1,
        TCP_GET_STATUS = 1,
        TCP_SET_NTP,
        TCP_FIRMWARE_UPDATE,
        TCP_RST_ASK,
        TCP_SD_RST_ASK
    }
}
