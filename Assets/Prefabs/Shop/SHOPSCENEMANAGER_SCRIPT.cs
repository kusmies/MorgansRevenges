using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHOPSCENEMANAGER_SCRIPT : MonoBehaviour
{
    public Text Name, Price, Description;
    AudioSource musicPlayer;
    public AudioClip shopSong;

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
        musicPlayer.clip = shopSong;

        musicPlayer.loop = true;

        musicPlayer.Play();
        }
    }
}
