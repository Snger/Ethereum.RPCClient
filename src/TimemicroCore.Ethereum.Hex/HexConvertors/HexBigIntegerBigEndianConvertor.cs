using System.Numerics;
using TimemicroCore.Ethereum.Hex.HexConvertors.Extensions;

namespace TimemicroCore.Ethereum.Hex.HexConvertors
{
    public class HexBigIntegerBigEndianConvertor: IHexConvertor<BigInteger>
    {  

        public string ConvertToHex(BigInteger newValue)
        {
            return newValue.ToHex(false);
        }

        public BigInteger ConvertFromHex(string hex)
        {
            return hex.HexToBigInteger(false);
        }

    }
}