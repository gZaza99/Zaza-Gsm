using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZazaGsm.Model
{
    public class DeviceImage : TableRecord
    {
        public DeviceImage(Device device)
        {
            Device = device;
            FrontBefore = BackBefore = FrontAfter = BackAfter = string.Empty;
        }
        public string FrontBefore { get; set; }
        public string BackBefore { get; set; }
        public string FrontAfter { get; set; }
        public string BackAfter { get; set; }
        public Device Device { get; set; }

        public override void CopyValuesFrom(IRecord other)
        {
            if (other.GetType() != typeof(Device))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Device)}");

            DeviceImage Other = (DeviceImage)other;
            FrontBefore = Other.FrontBefore;
            BackBefore = Other.BackBefore;
            FrontAfter = Other.FrontAfter;
            BackAfter = Other.BackAfter;
            Device = Other.Device;
        }

        public override bool Equals(Equatable obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{FrontBefore};{BackBefore};{FrontAfter};{BackAfter},{Device.Type}";
            byte[] bytes = MD5.HashData(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
    }
}
