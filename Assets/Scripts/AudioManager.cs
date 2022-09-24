using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource radioStation;

    public void ChangeRadio(AudioClip music)
    {
        if (radioStation.clip.name == music.name)
            return;

            radioStation.Stop();
            radioStation.clip = music;
            radioStation.Play();
    }
}
