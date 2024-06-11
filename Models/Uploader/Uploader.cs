using SuperSimpleTcp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Force.Crc32;

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
            Stopwatch sw = new Stopwatch();
            sw.Start();
    
            while(true)
            {
                if (sw.ElapsedMilliseconds > 30000)
                {
                    return false;
                }
                else if (response)
                {
                    response = false;
                    return true;
                }
                else if (client != null && !client.IsConnected)
                {
                    return false;
                }
            }
        }

        public bool sendNextPacked()
        {
            if (lastSentByte >= binFile.Length)
            {
                return false;
            }
            response = false;
            byte[] subArray = new byte[1024];
            int i = (binFile.Length - lastSentByte) < packedSize ? (binFile.Length - lastSentByte) : packedSize;
            Array.Copy(binFile, lastSentByte, subArray, 0, i);
            String crc = String.Format("0x{0:X}", Crc32CAlgorithm.Compute(subArray));
            string base64String = Convert.ToBase64String(subArray);
            if (client != null)
            {
                lastSentByte += i;
                string message = String.Format("{{\"command\": {0}, \"data\": \"{1}\", \"currentSize\": {2}, \"totalSize\": {3}, \"crc\": {4}}}", 3, base64String, lastSentByte, binFile.Length, crc);
                client.Send(message);
            }
            return true;
        }
    }
}
