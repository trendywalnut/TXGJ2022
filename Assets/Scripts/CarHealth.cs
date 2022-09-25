using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CarHealth : MonoBehaviour
{
    public int max_health = 3;
    public int current_health;

    public TextMeshProUGUI text;
    void Start()
    {
        current_health = max_health;
    }

    void Update()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        current_health -= damage;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
