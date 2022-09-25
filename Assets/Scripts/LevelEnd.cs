using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    public TextMeshProUGUI stopTheCarText;

    private void Start()
    {
        stopTheCarText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        stopTheCarText.gameObject.SetActive(true);
    }
}
