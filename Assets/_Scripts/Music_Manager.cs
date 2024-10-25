using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour
{
   
    private AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("Music") && !PlayerPrefs.HasKey("SoundEffects"))
        {
            PlayerPrefs.SetInt("Music", 0);
            PlayerPrefs.SetInt("SoundEffects", 0);
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            musicSource.Stop();
            musicSource.enabled = false;
        }
        
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            musicSource.enabled = true;
        }
    }

    private bool musiccounter;
    private bool effectcounter;
    public void Music()
    {
        if (!musiccounter)
        {
            PlayerPrefs.SetInt("Music", 1);
        }

        else
        {
            PlayerPrefs.SetInt("Music", 0);
        }

        musiccounter = !musiccounter;
    }

    public void SoundEffects()
    {
        if (!effectcounter)
        {
            PlayerPrefs.SetInt("SoundEffects", 1);

        }

        else
        {
            PlayerPrefs.SetInt("SoundEffects", 0);
        }

        effectcounter = !effectcounter;
    }
}
