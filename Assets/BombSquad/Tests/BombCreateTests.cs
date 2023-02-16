using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using BombSquad;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BombCreateTests
{
    [Test]
    public void whencreatingbombs_andarraybombsisempty_thenbombcountshouldbe5()
    {
        // arrange.
        BombCreater bombcreater = new(5);

        // act.
        bombcreater.CreateBombs();

        // assert.
        Assert.AreEqual(5, bombcreater.Bombs.Length);

    }
}
