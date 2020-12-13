using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFACT1_HANDLER_SCRIPT : MonoBehaviour
{
    public PLAYER_SCRIPT morgan;
    CHASEN_SCRIPT sceneChanger;
    public bool levelComplete = false;
    AudioSource musicPlayer;
    public AudioClip levelSong;
    public AudioClip victorySong;
    public AudioClip deathSong;
    public CAMERA_SCRIPT playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<CHASEN_SCRIPT>();
        musicPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.type = 1;

        if (!levelComplete && !musicPlayer.isPlaying && morgan.CurrentHealth > 0)
        {
            musicPlayer.clip = levelSong;

            musicPlayer.loop = true;

            musicPlayer.Play();
        }
        else if (levelComplete && musicPlayer.clip != victorySong)
        {
            musicPlayer.Stop();
            musicPlayer.clip = victorySong;
            musicPlayer.loop = false;
            musicPlayer.Play();
        }
        else if (morgan.CurrentHealth <= 0 && musicPlayer.clip != deathSong)
        {
            musicPlayer.Stop();
            musicPlayer.clip = deathSong;
            musicPlayer.loop = false;
            musicPlayer.Play();
        }
        
    }

    public void moveToDourFieldsAct2()
    {
        XMLManager.ins.SaveItems();
        SaveLoadManager.SavePlayer(morgan);
        XMLManager.ins.PermSaveItems();
        sceneChanger.changeScene(5);
    }
}
