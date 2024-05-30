using SuperSimpleTcp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace SampleFileUploader.Models.Uploader
{
    public class Uploader
    {
        public byte[] binFile = Array.Empty<Byte>();
        public bool response = false;
        public bool keepSend = false;
        Int64 timer = 0;
        int lastSentByte = 0;
        int packedSize = 1024;

        SimpleTcpClient? client;
        public void clear()
        {
            binFile = Array.Empty<Byte>();
            lastSentByte = 0;
        }
        public void setClient(SimpleTcpClient client)
        {
            this.client = client;
        }
        public void deleteClient()
        {
            client = null;
        }

        public bool waitResponseFlag()
        {
            if (response)
            {
                return true;
            }
            else
            {
                return checkTimer();
            }
        }

        private bool checkTimer()
        {
            timer++;
            if (timer > 50000)
            {
                timer = 0;
                keepSend = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void sendNextPacked()
        {
            byte[] subArray = new byte[1024];
            Array.Copy(binFile, lastSentByte, subArray, 0, packedSize);

            string base64String = Convert.ToBase64String(subArray);
        }
    }
}
