using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAINMEN_SCRIPT : MonoBehaviour
{
    AudioSource musicPlayer;
    public AudioClip mainSong;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicPlayer.isPlaying)
        {
            musicPlayer.clip = mainSong;

            musicPlayer.loop = true;

            musicPlayer.Play();
        }
    }
}
