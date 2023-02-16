using BombSquad;
using NUnit.Framework;
using System.Collections.Generic;

public class BombCreateTests
{
    [Test]
    public void WhenCreatingBombs_AndArrayBombsIsEmpty_ThenBombCountShouldBe5()
    {
        // arrange.
        BombCreater bombcreater = new(5);

        // act.
        bombcreater.CreateBombs();

        // assert.
        Assert.AreEqual(5, bombcreater.Bombs.Length);
    }

    [Test]
    public void WhenCreatingBombs_AndArrayBombCountIs5_ThenAllBombHaveDifferentCoords()
    {
        // Arrange.
        BombCreater bombCreater = new(5);

        // Act.
        bombCreater.CreateBombs();
        int numCollisions = 0;
        int n = 0;
        while(n< 5)
        {
            Bomb bomb = bombCreater.Bombs[n];
            foreach (Bomb bmb in bombCreater.Bombs)
            {
                if (bomb.IsEqualsBobm(bmb))
                {
                    numCollisions++;
                }
            }
            n++;
        }

        // Assert.
        Assert.AreEqual(5, numCollisions);
    }
}
