using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolverGame.Data;

namespace TestingUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddBulletTest()
        {
            RevolverCylinder cylinder = new RevolverCylinder();
            cylinder.LoadTheBullet(2);
            Assert.AreEqual(cylinder.FireBullet(0), false);
        }

        [TestMethod]
        public void FireBulletTest()
        {
            RevolverCylinder cylinder = new RevolverCylinder();
            cylinder.LoadTheBullet(0);
            Assert.AreEqual(cylinder.FireBullet(0), true);
        }
    }
}
