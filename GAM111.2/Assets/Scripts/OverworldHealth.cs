using UnityEngine;
using UnityEngine.UI;

public class OverworldHealth : MonoBehaviour
{
    public Image healthBar;
    void Start()
    {
        healthBar.fillAmount = GameManager.instance.RetrieveHealth();    
    }

    public void IncreaseHealth (float amount)
    {
        healthBar.fillAmount += amount;
    }

    public void DecreaseHealth (float amount)
    {
        healthBar.fillAmount -= amount;
    }
}
