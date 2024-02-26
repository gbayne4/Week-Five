using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    AudioClip backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        //Loading Music
        MusicManager.instance.SwitchMusic(backgroundMusic);
    }

    public void StartGame()
    {
        //Loading Scene
        SceneManager.LoadScene("GameScene");
    }
}
