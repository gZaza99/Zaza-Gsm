using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZazaGsm.BackEndTest
{
    [TestClass]
    public class HashCodeTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            byte[] code = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            Base.HashCode Hash = new Base.HashCode(code);

            Assert.AreEqual("000102030405060708090A0B0C0D0E0F", Hash.ToString());
        }

        [TestMethod]
        public void EqualtionTest()
        {
            Base.HashCode Hash1 = new Base.HashCode(
                new byte[16] {
                    0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                    0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F
                }
            );

            Base.HashCode Hash2 = new Base.HashCode(
                new byte[16] {
                    0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                    0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F
                }
            );

            Base.HashCode Hash3 = new Base.HashCode(
                new byte[16] {
                    0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08,
                    0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00
                }
            );

            Base.HashCode Hash4 = null;
            Base.HashCode Hash5 = null;

            Assert.IsTrue(Hash1 == Hash2);
            Assert.IsFalse(Hash1 == Hash3);
            Assert.IsFalse(Hash1 == Hash4);
            Assert.IsTrue(Hash5 == Hash4);
        }
    }
}