using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClassCollection
{
    public class Convertion
    {
        /*
        *   将字节数组转化为十六进制的字符串
        *   params: byte[]
        *   return： string
        */
        public string ByteToHex(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /*
         *   判断字符串是否是十六进制
         *   params: string
         *   return： bool
         */
        public bool IsHexadecimal(string str)
        {
            const string pattern = @"([^A-Fa-f0-9\s]+?)+";
            return System.Text.RegularExpressions.Regex.IsMatch(str, pattern);
        }

        /*
        *   将十六进制字符串转化为字节数组
        *   params: string
        *   return： byte[]
        */
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            if (s.Length % 2 != 0)
            {
                s = s.Remove(s.Length-2,1);
            }
            byte[]  buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
            return buffer;
        }


        /*
        *   将字节数组转化为十六进制字符串
        *   params: byte[]
        *   return： string
        */
        public string ByteToHexStr(byte[] bytes)
        {
            string hexStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    hexStr += bytes[i].ToString("X2");
                }
            }
            return hexStr;
        }

        /*
        *   对于十六进制字符串：每隔两个字符插入空格
        *   params: string
        *   return： string
        */
        public string InsertSpace(string input)
        {
            input = input.Replace(" ", "");
            for (int i = 2; i < input.Length; i += 3)
                input = input.Insert(i, " ");
            return input;
        }


        /*
        *   获取本地IP地址
        *   return： string
        */
        public string GetIP()
        {
            string HostName = Dns.GetHostName();
            string ip = null;
            IPHostEntry ipEntry = Dns.GetHostEntry(HostName);
            for (int i = 0; i < ipEntry.AddressList.Length; i++)
            {
                if (ipEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ip = ipEntry.AddressList[i].ToString();
                }
            }
            return ip;
        }
    }
}
