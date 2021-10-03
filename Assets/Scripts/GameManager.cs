using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get { return _instance; } }

    public static GameManager _instance;

    public int waveID;

    float musicVol = .5f;
    float soundVol = .5f;

    public GameObject deathPanel;
    public GameObject winPanel;
  

    public bool dead;
    public bool win;



    private void Awake()
    {
        /*
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        */

        _instance = this;

        DontDestroyOnLoad(_instance);




    }

    private void Start()
    {
        Time.timeScale = 1;
    }


    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Death()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
        dead = true;

    }

    public void Win()
    {
        winPanel.SetActive(true);
        win = true;
        Time.timeScale = 0;

    }

    public bool isDead()
    {
        if (dead)
            return true;
        else
            return false;
    }

    public bool hasWon()
    {
        if (win)
            return true;
        else
            return false;
    }

    public void SetMusicVol(float vol)
    {
        musicVol = vol;
    }

    public void SetSoundVol(float vol)
    {
        soundVol = vol;
    }

    public float GetMusicVol()
    {
        return musicVol;
    }

    public float GetSoundVol()
    {
        return soundVol;
    }



}
