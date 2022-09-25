using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CarHealth : MonoBehaviour
{
    public int max_health = 3;
    public int current_health;

    //audio
    public AudioClip[] impactSoundArray;
    private AudioManager theAM;

    public TextMeshProUGUI text;
    void Start()
    {
        current_health = max_health;

        theAM = FindObjectOfType<AudioManager>();

    }

    void Update()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        current_health -= damage;

        //audio
        theAM.ImpactSFXPlayer(RandomClip());

        if(current_health <= 0)
        {
            ResetLevel();
        }
    }

    private void UpdateUI()
    {
        text.SetText(current_health.ToString());
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene("Lose Scene");
    }


    AudioClip RandomClip()
    {
        return impactSoundArray[Random.Range(0, impactSoundArray.Length-1)];
    }
}
