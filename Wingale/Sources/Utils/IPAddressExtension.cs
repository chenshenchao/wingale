using System;
using System.Net;

namespace Wingale.Utils
{
    public static class IPAddressExtension
    {
        public static IPAddress GetNet(this IPAddress address, IPAddress netmask)
        {
            byte[] data = address.GetAddressBytes();
            byte[] mask = netmask.GetAddressBytes();
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] &= mask[i];
            }
            return new IPAddress(data);
        }

        public static IPAddress GetBroadcast(this IPAddress address, IPAddress netmask)
        {
            byte[] data = address.GetAddressBytes();
            byte[] mask = netmask.GetAddressBytes();
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = (byte)(~mask[i] | data[i]);
            }
            return new IPAddress(data);
        }

        public static IPAddress Next(this IPAddress address)
        {
            byte[] data = address.GetAddressBytes();
            for (int i = data.Length - 1; i >= 0; --i)
            {
                if (data[i] != 255)
                {
                    ++data[i];
                    break;
                }
                else
                {
                    data[i] = 0;
                }
            }
            return new IPAddress(data);
        }

        public static long Count(this IPAddress netmask)
        {
            int capacity = 0;
            byte[] mask = netmask.GetAddressBytes();
            for (int i = 0; i < mask.Length; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if ((mask[i] & (1 << j)) == 0)
                    {
                        ++capacity;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return (1 << capacity) - 2;
        }
    }
}
