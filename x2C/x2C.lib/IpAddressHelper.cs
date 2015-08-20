using System.Linq;
using System.Net;

namespace x2C.lib
{
	public static class IpAddressHelper
	{
		public static bool IsCompatible(this IPAddress ip)
		{
			if (ip.GetAddressBytes().First() == 10)
			{
				if (ip.GetAddressBytes()[3] < 11)
				{
					return false;
				} return true;
			}
			if (ip.GetAddressBytes()[0] == 172 && (ip.GetAddressBytes()[1] >= 16 && ip.GetAddressBytes()[1] < 32))
			{
				if (ip.GetAddressBytes()[3] < 11)
				{
					return false;
				}
				return true;
			}
			if (ip.GetAddressBytes()[0] == 192 && ip.GetAddressBytes()[1] == 168)
			{
				if (ip.GetAddressBytes()[3] < 11)
				{
					return false;
				} 
				return true;
			}
			return false;
		}
	}
}
