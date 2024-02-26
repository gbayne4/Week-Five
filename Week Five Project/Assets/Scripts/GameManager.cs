using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utilities;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    [SerializedField]
    AudioClip backgroundMusic;
   

    public static GameManager instance;

    public bool isGameOver = false;

    /*
    public struct fish //tried this and it failed :(
    {
        public int numLeft;
    }
    */

    void Start()
    {
        //fish fishies;
        //fishies.numLeft = 18;

        //Loading Music
        MusicManager.instance.SwitchMusic(backgroundMusic);
    }

    void Update()
    {
        if (PlayPlayer.fish == 0)
        {
            GameOver();
        }
    }

    private void Awake() //using singleton 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject); //avoid duplicates
        }


    }
    public void GameOver()
        {
            isGameOver = true;
        }
}
