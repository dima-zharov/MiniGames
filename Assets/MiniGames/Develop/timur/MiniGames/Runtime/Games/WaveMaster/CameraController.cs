using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPos;
    public float yOffset = 3f;
    float smoothTime = 0.15f;
    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        playerPos = player.transform.position;

        Vector3 targetPos = CalcNewCameraTransformation(playerPos, yOffset);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
    
    public Vector3 CalcNewCameraTransformation(Vector3 playerPos, float yOffset)
    {
        Vector3 targetPos = new Vector3(playerPos.x, playerPos.y + yOffset, playerPos.z - 10);
        return new Vector3(0, targetPos.y, targetPos.z);
    } 
}