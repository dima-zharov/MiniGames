using NUnit.Framework;
using UnityEngine.TestTools.Utils;

public class PlayerControllerTest
{

    [Test]
    public void PlayerController_Test()
    {
        var comparer = new FloatEqualityComparer(10e-5f);

        var playerController = new PlayerController();

        float[] needPosX = new float[3] {-1.99841f, 4.441169f, 83.45578f};
        float[] newPosX = new float[3]; 
        float[] x = new float[3] { 0, 5, 78 };
        float[] delta = new float[3] { 2, 2, 6 };
        float[] time = new float[3] { 33, 2, 0.4f };
        float[] lrSpeed = new float[3] { 3, 3, 5 };

        for (int i = 0; i < needPosX.Length; i++)
        {
            newPosX[i] = playerController.ReturnNewPosX(x[i], delta[i], time[i], lrSpeed[i]);
            Assert.That(newPosX[i], Is.EqualTo(needPosX[i]).Using(comparer));
        }
    }
}
