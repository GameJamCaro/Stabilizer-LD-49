using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    public bool isInCenter;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Center") 
        {
            isInCenter = true;
            Debug.Log("in center");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Center")
        {
            isInCenter = false;
        }
    }
}
