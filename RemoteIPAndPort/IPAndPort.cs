using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ClassCollection
{
    public struct IPAndPort : IEquatable<IPAndPort>
    {
        public IPAddress ip;
        public int port;
        public IPAndPort(IPAddress ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public override string ToString()
        {
            return ip.ToString() + "   " + port.ToString();
        }

        public override int GetHashCode()
        {
            return (port << 16) * 0x15051505;
        }

        public bool Equals(IPAndPort other)
        {
            if (other == null)
            {
                return false;
            }
            return (ip.ToString() == other.ip.ToString() && port == other.port);
        }

        public override bool Equals(object obj)
        {
            return Equals((IPAndPort)obj);
        }

        public static bool operator ==(IPAndPort left,IPAndPort right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IPAndPort left,IPAndPort right)
        {
            return !(left==right);
        }
 
    }
}
