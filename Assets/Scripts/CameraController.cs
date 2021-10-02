using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    Vector3 camPosition;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        camPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, camPosition.y, camPosition.z);
    }
}
