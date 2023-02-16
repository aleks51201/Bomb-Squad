using Assets.Scripts;
using NUnit.Framework;

namespace BombSquadTest1
{
    public class BombCreaterTests
    {
        [Test]
        public void WhenCreatingBombs_AndArrayBombsIsEmpty_ThenBombCountShouldBe5()
        {
            // Arrange.
            BombCreater bombCreater = new(5);

            // Act.
            bombCreater.CreateBombs();

            // Assert.
            Assert.AreEqual(5, bombCreater.Bombs.Length);

        }

    }
}