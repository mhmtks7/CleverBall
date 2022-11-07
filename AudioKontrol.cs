using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioKontrol : MonoBehaviour
{
    public AudioClip[] Player;

    
    void Start()
    {
        int RandomClip = Random.Range(0, Player.Length);

        GetComponent<AudioSource>().clip = Player[RandomClip];
        if (PlayerPrefs.HasKey("AudioRecord"))
        {
            transform.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("AudioRecord") / 5;
        }
        else
        {
            transform.GetComponent<AudioSource>().volume = 0.6f;
        }
        /*
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GetComponent<AudioSource>().mute = true;
        }
        */
    }

}
