using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleFileUploader.Models.Uploader.Enums;

namespace SampleFileUploader.Models.Uploader
{
    public class ServerResponse
    {
        public TcpCommand command;
        public Reason reason;
        public UInt32 deviceId;
        public bool result;
    }
}
