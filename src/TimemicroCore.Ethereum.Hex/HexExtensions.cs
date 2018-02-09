using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TimemicroCore.Ethereum.Hex.HexTypes
{
    public static class HexExtensions
    {
        private const long ctowei = 1000000000000000000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static decimal HexToEther(this HexBigInteger hex)
        {
            if (hex != null)
            {
                return decimal.Parse(hex.Value.ToString()) / ctowei;
            }
            return 0;
        }

        public static string EtherToWeiHex(this decimal value)
        {
            return new HexBigInteger(BigInteger.Parse((value * ctowei).ToString())).HexValue;
        }
    }
}
