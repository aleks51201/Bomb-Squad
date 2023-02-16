using Assets.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace BombSquadTest
{
    [TestClass]
    public class BombCounterTest
    {
        [TestMethod]
        public void FiveBombInArrayCheck()
        {
            //Arrange
            BombCreater bombCreater = new(5);

            //Act
            bombCreater.CreateBombs();

            //Assert
            Assert.AreEqual(6, bombCreater.Bombs.Length);
        }
    }
}
