using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Transform unstablePlane;
    float tilt;
    int time;
    int stableTime = 0;
    public TextMeshProUGUI tiltUI;
    public TextMeshProUGUI stableUI;
    public TextMeshProUGUI pointUI;
    public TextMeshProUGUI winPoints;
    public bool stable;
    bool once;
    bool once1;
    int points;
    public PlayerController playerScript;

    
    // Start is called before the first frame update
    void Start()
    {
       // time = stableTime;
    }

    // Update is called once per frame
    private void Update()
    {
        tilt = unstablePlane.rotation.z * 100;
        
        tiltUI.text = tilt.ToString("n2");

        if (tilt < 1f && tilt > -1f)
        {
            stable = true;
            stableUI.text = "balanced";
        }
        else
        {
            stable = false;
            once = false;
            once1 = false;
            stableUI.text = "unbalanced";
            stableTime = 0;
           
           
        }

        if (stable && !once) 
        {
            StartCoroutine(Timer());
            once = true;
        }
        if (stableTime == 0)
        {
            stableUI.color = Color.black;
        }
       
       
        if (stableTime == 1)
        {
            stableUI.color = Color.green;
            if (!once1)
            {
               
                if (playerScript.isInCenter) 
                {
                    points += 10;
                }
                else
                {
                    points++;
                }
               
                pointUI.text = points + " points";
                winPoints.text = points + " points";
                once1 = true;
            }
               
        }
    }

    IEnumerator Timer() 
    {
        yield return new WaitForSeconds(3);
        stableTime++;
        StartCoroutine(Timer());
    }


}
