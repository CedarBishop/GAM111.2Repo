using System.Collections;
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
    public AudioClip gameOverSound;
    public AudioClip winBattleSound;

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
            StartCoroutine("PlayerLost");
        }
        else if (enemyHpImage.fillAmount <= 0)
        {
            StartCoroutine("PlayerWins");
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
    IEnumerator PlayerLost ()
    {
        yield return new WaitForSeconds(2);
        SoundManager.instance.RandomizePitchAndPlay(gameOverSound);
        SoundManager.instance.StartCoroutine("CrossFadeToOverworld");
        SceneManager.LoadScene("MainMenuScene");
        StopCoroutine("PlayerLost");
    }

    IEnumerator PlayerWins ()
    {
        yield return new WaitForSeconds(2);
        SoundManager.instance.RandomizePitchAndPlay(winBattleSound);
        SoundManager.instance.StartCoroutine("CrossFadeToOverworld");
        GameManager.instance.StoreHealth(playerHpImage.fillAmount);
        SceneManager.LoadScene("Overworld");
        StopCoroutine("PlayerWins");
    }
}
