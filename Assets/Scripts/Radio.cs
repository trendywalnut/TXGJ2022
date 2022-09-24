using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioClip[] audioClipArray;
    private AudioManager theAM;
    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        changeStation();
    }

    void changeStation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[0]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[1]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[2]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[3]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[4]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[5]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[6]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[7]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[8]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (audioClipArray != null)
                theAM.ChangeRadio(audioClipArray[9]);
        }
    }
}
