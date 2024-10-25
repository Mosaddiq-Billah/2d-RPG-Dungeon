using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class option_panel_Script : MonoBehaviour
{
    public GameObject TickMusic;
    public GameObject UnTickMusic;
    public GameObject TickEffect;
    public GameObject UnTickEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            TickMusic.SetActive(false);
            UnTickMusic.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            TickMusic.SetActive(true);
            UnTickMusic.SetActive(false);

        }

        if (PlayerPrefs.GetInt("SoundEffects") == 1)
        {
            TickEffect.SetActive(false);
            UnTickEffect.SetActive(true);
        }

        if (PlayerPrefs.GetInt("SoundEffects") == 0)
        {
            TickEffect.SetActive(true);
            UnTickEffect.SetActive(false);
        }
    }
}
