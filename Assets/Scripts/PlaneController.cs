using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
    public Vector3[] startPos;
    int startID;
    Vector3 tempPos;
    public float speed;
    public GameObject[] cubes;
    bool rightToLeft;
    public int waveTime;
    int waveTimer;
    public TextMeshProUGUI timerUI;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        waveTimer = waveTime;
        StartCoroutine(WaveTimer());
        
        startID = 1;
        tempPos = startPos[startID];
        StartCoroutine(StartAndSpawn());

       

    }

    // Update is called once per frame
    void Update()
    {
        if (startID == 0)
        {
            tempPos.x += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            tempPos.x -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        transform.position = tempPos;

        if (waveTimer < 1  && !GameManager._instance.dead) 
        {
            GameManager._instance.Win();
            GameManager._instance.waveID++;
          
        }
      


    }

    void SpawnCube()
    {
        Instantiate(cubes[Random.Range(0, cubes.Length-1)],new Vector3(gameObject.transform.position.x, 27, 0), gameObject.transform.rotation);
        Debug.Log("spawn");
    }

    IEnumerator StartAndSpawn()
    {
        yield return new WaitForSeconds(7);
        SpawnCube();
        yield return new WaitForSeconds(Random.Range(3, 4));
        SpawnCube();
       
      
        yield return new WaitForSeconds(Random.Range(5, 20));
        startID = Random.Range(0, 1);
        tempPos = startPos[startID];
        StartCoroutine(WaitAndSpawnRandom());



    }

    IEnumerator StartAndSpawn1()
    {
        yield return new WaitForSeconds(6);
        SpawnCube();
        yield return new WaitForSeconds(Random.Range(2, 3));
        SpawnCube();
        yield return new WaitForSeconds(Random.Range(2, 3));
        SpawnCube();
      


        yield return new WaitForSeconds(Random.Range(5, 20));
        startID = Random.Range(0, 1);
        tempPos = startPos[startID];
        StartCoroutine(WaitAndSpawnRandom());



    }

    IEnumerator StartAndSpawn2()
    {
        yield return new WaitForSeconds(5);
        SpawnCube();
        yield return new WaitForSeconds(Random.Range(2, 3));
        SpawnCube();
        yield return new WaitForSeconds(Random.Range(2, 3));
        SpawnCube();
        yield return new WaitForSeconds(Random.Range(2, 3));
        SpawnCube();


        yield return new WaitForSeconds(Random.Range(5, 20));
        startID = Random.Range(0, 1);
        tempPos = startPos[startID];
        StartCoroutine(WaitAndSpawnRandom());



    }




    IEnumerator WaitAndSpawnRandom()
    {
        yield return new WaitForSeconds(Random.Range(8, 13));
        SpawnCube();
       
        yield return new WaitForSeconds(30);
        startID = Random.Range(0, 1);
        tempPos = startPos[startID];
        StartCoroutine(WaitAndSpawnRandom());

    }

    IEnumerator WaveTimer()
    {
        yield return new WaitForSeconds(1);
        waveTimer--;
        timerUI.text = waveTimer + " Seconds";
        StartCoroutine(WaveTimer());

    }
}
