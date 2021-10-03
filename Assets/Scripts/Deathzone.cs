using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
   

    private void Start()
    {
       
        Time.timeScale = 1;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            Debug.Log("deadzone");
            GameManager._instance.Death();
            Time.timeScale = 0;


        }
    }


}
