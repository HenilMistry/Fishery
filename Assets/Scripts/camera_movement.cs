using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3(0,0,-10f);

    // Start is called before the first frame update
    void Start()
    {
        Follow();
    }

    void Follow() {
        Vector3 targetPos = player.transform.position + offset;
        this.transform.position = targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
