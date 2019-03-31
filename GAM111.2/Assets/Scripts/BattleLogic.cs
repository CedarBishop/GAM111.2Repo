using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BattleLogic : MonoBehaviour
{
    public Image playerHpImage;
    public Image enemyHpImage;
    public Text playerHpText;
    public Text enemyHpText;
    public TMPro.TextMeshProUGUI enemyName;

    void Start()
    {
        FindEnemyName();
    }

    void Update()
    {
        playerHpText.text = "HP: " + (playerHpImage.fillAmount * 100).ToString("F0");
        enemyHpText.text = "HP: " + (enemyHpImage.fillAmount * 100).ToString("F0");
        if (playerHpImage.fillAmount <= 0)
        {
            PlayerLost();
        }
        else if (enemyHpImage.fillAmount <= 0)
        {
            PlayerWins();
        }
    }

    void FindEnemyName ()
    {
        if (GameManager.instance.ReturnEnemyType() == 1)
        {
            enemyName.text = "McChicken";
        }
        else if (GameManager.instance.ReturnEnemyType() == 2)
        {
            enemyName.text = "McDonald";
        }
        else if (GameManager.instance.ReturnEnemyType() == 3)
        {
            enemyName.text = "McRib";
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        playerHpImage.fillAmount -= (damage / 100);
    }

    public void EnemyTakeDamage (float damage)
    {
        enemyHpImage.fillAmount -= (damage / 100);
    }
    public void PlayerHeals (float amount)
    {
        playerHpImage.fillAmount += (amount / 100);
    }
    void PlayerLost ()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    void PlayerWins ()
    {
        GameManager.instance.StoreHealth(playerHpImage.fillAmount);
        SceneManager.LoadScene("Overworld");
    }
}
