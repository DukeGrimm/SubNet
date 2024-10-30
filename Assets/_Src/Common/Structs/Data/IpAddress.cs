using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace SubNet.Common.Structs.Data
{
    public struct IpAddress
    {
        [OdinSerialize]
        private byte[] address;
        public IpAddress(string newAddressString)
        {
            address = new byte[4];
            SetAddress(newAddressString);
        }

        private void SetAddress(string newAddressString) {

            string[] octStrings = newAddressString.Split('.');
            if (octStrings.Length == 4)
            {
                for (int octIndex = 0; octIndex < octStrings.Length; octIndex++)
                {
                    byte newOct;
                    byte.TryParse(octStrings[octIndex], out newOct);
                    address[octIndex] = newOct;
                }
            }
        }

        [Button("New IP")]
        private void SetNewAddress()
        {
            address = new byte[4];
            for (int octIndex = 0; octIndex < address.Length; octIndex++) 
                {
                    byte newOct;
                    newOct = (byte)Random.Range(0, 256);
                    address[octIndex] = newOct;
                }
        }

        public static implicit operator string(IpAddress ip) => ip.ToString();

        public override string ToString()
        {
            return $"{address[0]}.{address[1]}.{address[2]}.{address[3]}";
        }


    }
}
