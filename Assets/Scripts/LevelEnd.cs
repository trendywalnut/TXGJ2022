using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public TextMeshProUGUI stopTheCarText;
    public CarMovement carMovement;

    private bool goalMet = false;
    private void Start()
    {
        stopTheCarText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        stopTheCarText.gameObject.SetActive(true);
        goalMet = true;
    }

    private void Update()
    {
        if(carMovement.handBrakePulled && goalMet)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }
}
