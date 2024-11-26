using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGsm.Base
{
    public class DeviceImage : TableRecord
    {
        public DeviceImage(Issue issue)
        {
            Issue = issue;
            FrontBefore = BackBefore = FrontAfter = BackAfter = string.Empty;
        }

        internal string _frontBefore;
        public string FrontBefore
        {
            get => _frontBefore;
            set => SetProperty(ref _frontBefore, value);
        }
        internal string _backBefore;
        public string BackBefore
        {
            get => _backBefore;
            set => SetProperty(ref _backBefore, value);
        }
        internal string _frontAfter;
        public string FrontAfter
        {
            get => _frontAfter;
            set => SetProperty(ref _frontAfter, value);
        }
        internal string _backAfter;
        public string BackAfter
        {
            get => _backAfter;
            set => SetProperty(ref _backAfter, value);
        }
        internal Issue _issue;
        public Issue Issue
        {
            get => _issue;
            set => SetProperty(ref _issue, value);
        }

        public override void CopyValuesFrom(IRecord other)
        {
            if (other.GetType() != typeof(Device))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Device)}");

            DeviceImage Other = (DeviceImage)other;
            _frontBefore = Other.FrontBefore;
            _backBefore = Other.BackBefore;
            _frontAfter = Other.FrontAfter;
            _backAfter = Other.BackAfter;
            Issue = Other.Issue;
        }

        protected override void SetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{FrontBefore};{BackBefore};{FrontAfter};{BackAfter},{Issue.TableKey}";
            byte[] bytes = mD5.ComputeHash(UTF8.GetBytes(hashString));
            Hash = new ZazaGsm.Base.HashCode(bytes);
        }
    }
}
