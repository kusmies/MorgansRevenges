using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFACT2_HANDLER_SCRIPT : MonoBehaviour
{
    public LANCEL_SCRIPT lancelot;
    public PLAYER_SCRIPT morgan;
    public Vector2 playerPosition;
    public bool lancelotDefeated = false;
    public CHASEN_SCRIPT sceneChangeScript;
    AudioSource musicPlayer;
    public AudioClip bossSong;
    public AudioClip victorySong;
    public AudioClip deathSong;
    public CAMERA_SCRIPT playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        sceneChangeScript = GetComponent<CHASEN_SCRIPT>();
        musicPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.type = 2;
        playerPosition = new Vector2(morgan.transform.position.x, morgan.transform.position.y);

        if (!lancelotDefeated && !musicPlayer.isPlaying && morgan.CurrentHealth > 0)
        {
            musicPlayer.clip = bossSong;

            musicPlayer.loop = true;

            musicPlayer.Play();
        }
        else if (lancelotDefeated && musicPlayer.clip != victorySong)
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

    public void endScene()
    {

        morgan.itemcleaner();
          XMLManager.ins.SaveItems();
        SaveLoadManager.SavePlayer(morgan);
        XMLManager.ins.PermSaveItems();
        sceneChangeScript.changeScene(7);
    }
}
