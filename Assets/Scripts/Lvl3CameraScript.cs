using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3CameraScript : MonoBehaviour
{
    public Vector3 Offset;
    public Transform player;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 finalPosition = player.position + Offset;
        transform.position = Vector3.Lerp(transform.position, finalPosition, cameraSpeed * Time.deltaTime);
    }
}
