using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager instance;

        AudioSource source;

        private void Awake()
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

            source = GetComponent<AudioSource>();
        }

        //anytime I want to switch music I can just passs it into here
        public void SwitchMusic(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
