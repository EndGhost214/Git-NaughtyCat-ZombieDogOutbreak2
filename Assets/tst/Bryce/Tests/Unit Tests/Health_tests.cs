
using UnityEngine;
using NUnit.Framework;

public class Health_tests : MonoBehaviour
{



    [Test]
    public void checkPlayerHealthisFull()
    {
        SurvivalPlayer bob = new SurvivalPlayer(new Player());
        float check;
        check = bob.GetHealth();
        Assert.AreEqual(check, 100);
    }

    [Test]
    public void checkPlayerHealthAfterDamage()
    {

        SurvivalPlayer bob = new SurvivalPlayer(new Player());
        float check;
        bob.DamagePlayer(50);
        check = bob.GetHealth();
        Assert.AreEqual(check, 50);
    }

    [Test]
    public void checkPlayerHealthAfterDamageMax()
    {

        SurvivalPlayer bob = new SurvivalPlayer(new Player());
        float check;
        bob.DamagePlayer(500);
        check = bob.GetHealth();
        Assert.AreEqual(check, 0);
    }

    [Test]
    public void checkPlayerHealthAfterMinDamage()
    {
        SurvivalPlayer bob = new SurvivalPlayer(new Player());
        float check;
        bob.DamagePlayer(.5f);
        check = bob.GetHealth();
        Assert.AreEqual(check, 100);
    }
}
