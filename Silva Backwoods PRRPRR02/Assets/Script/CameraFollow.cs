using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPosition = player.position + offset;
        Vector3 smoothCameraPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed);
        transform.position = smoothCameraPosition;

        //fastnar i spelet när man går runt!! //Brackeys
    }

}
