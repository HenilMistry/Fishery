using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    // player object...
    public GameObject player;
    Vector3 offset = new Vector3(0,0,-10f);
    public float speed = 0.04f;

    public Vector3 CameraMinPos;
    public Vector3 CameraMaxPos;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        Follow();
    }

    void Follow() {
        Vector3 targetPos = player.transform.position + offset;

        Vector3 boundedPos = new Vector3(Mathf.Clamp(targetPos.x,CameraMinPos.x,CameraMaxPos.x),
                         Mathf.Clamp(targetPos.y,CameraMinPos.y,CameraMaxPos.y),
                        Mathf.Clamp(targetPos.z,CameraMinPos.z,CameraMaxPos.z));

        Vector3 smoothPos = Vector3.Lerp(transform.position,boundedPos, speed);

        this.transform.position = smoothPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
