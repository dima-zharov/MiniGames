using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools.Utils;

public class CameraControllerTest
{
    [Test]
    public void CameraController_Test()
    {
        Vector3 velocity = Vector3.zero;

        var comparer = new FloatEqualityComparer(10e-3f);
        
        CameraController cameraController = new CameraController();

        Vector3[] playerPos = new Vector3[4] 
        {new Vector3(813, 282, 732), 
        new Vector3(50, 741, 452),
        new Vector3(858, 785, 883),
        new Vector3(526, 191, 115)
        };        

        Vector3[] cameraPos = new Vector3[4] 
        {new Vector3(0, 314.4f, 722), 
        new Vector3(0, 803, 442),
        new Vector3(0, 860.8f, 873),
        new Vector3(0, 237.9f, 105)
        };

        float[] yOffset = new float[4] {32.4f, 62, 75.8f, 46.9f};


        for(int i = 0; i < playerPos.Length; i++)
        {
            Assert.That(cameraController.CalcNewCameraTransformation(playerPos[i], yOffset[i]), Is.EqualTo(cameraPos[i]).Using(comparer));
        }
    }

}
