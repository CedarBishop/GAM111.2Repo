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
    public Image playerHitImage;
    public Image enemyHitImage;
    public AudioClip takeDamageSound;
    EnemyAttacks enemyAttacks;
    public PlayerAttacks playerAttacks;
    bool activeToggle = false;
    int count = 0;
    void Start()
    {
        FindEnemyName();
        playerHitImage.gameObject.SetActive(false);
        enemyHitImage.gameObject.SetActive(false);
    }

    void Update()
    {
        playerHpText.text = "HP: " + (playerHpImage.fillAmount * 100).ToString("F0");
        enemyHpText.text = "HP: " + (enemyHpImage.fillAmount * 100).ToString("F0");
        if (playerHpImage.fillAmount < 0.01f)
        {
            StartCoroutine("PlayerLost");
        }
        else if (enemyHpImage.fillAmount < 0.01f)
        {
            StartCoroutine("PlayerWins");
            if (GameManager.instance.ReturnEnemyType() == 1)
            {
                enemyAttacks = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<EnemyAttacks>();
                enemyAttacks.EnemyFainted();
            }
            else if (GameManager.instance.ReturnEnemyType() == 2)
            {
                enemyAttacks = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<EnemyAttacks>();
                enemyAttacks.EnemyFainted();
            }
            else if (GameManager.instance.ReturnEnemyType() == 3)
            {
                enemyAttacks = GameObject.FindGameObjectWithTag("Enemy3").GetComponent<EnemyAttacks>();
                enemyAttacks.EnemyFainted();
            }
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
        count = 0;
        float newHealth = playerHpImage.fillAmount - (damage / 100);
        SoundManager.instance.RandomizePitchAndPlay(takeDamageSound);
        StartCoroutine("GradualPlayerHealthDecrease", newHealth);
        StartCoroutine("FlickerPlayerHitImage");
    }

    public void EnemyTakeDamage (float damage)
    {
        count = 0;
        float newHealth = enemyHpImage.fillAmount - (damage/100);
        SoundManager.instance.RandomizePitchAndPlay(takeDamageSound);
        StartCoroutine("GradualEnemyHealthDecrease", newHealth);
        StartCoroutine("FlickerEnemyHitImage");
    }
    public void PlayerHeals (float amount)
    {
        float newHealth = playerHpImage.fillAmount + (amount / 100);
        StartCoroutine("GradualPlayerHealthIncrease", newHealth);
    }
    IEnumerator PlayerLost ()
    {
        SoundManager.instance.RandomizePitchAndPlay(gameOverSound);
        yield return new WaitForSeconds(3);        
        SoundManager.instance.StartCoroutine("CrossFadeToOverworld");
        SceneManager.LoadScene("MainMenuScene");
        StopCoroutine("PlayerLost");
    }

    IEnumerator PlayerWins ()
    {
        playerAttacks.PlayerFainted();
        yield return new WaitForSeconds(3);
        SoundManager.instance.RandomizePitchAndPlay(winBattleSound);
        SoundManager.instance.StartCoroutine("CrossFadeToOverworld");
        GameManager.instance.StoreHealth(playerHpImage.fillAmount);
        SceneManager.LoadScene("Overworld");
        StopCoroutine("PlayerWins");
    }
    IEnumerator GradualEnemyHealthDecrease (float newHp)
    {
        while (enemyHpImage.fillAmount > newHp)
        {
            enemyHpImage.fillAmount -= 0.01f;
            yield return null;
        }
    }
    IEnumerator GradualPlayerHealthDecrease(float newHp)
    {
        while (playerHpImage.fillAmount > newHp)
        {
            playerHpImage.fillAmount -= 0.01f;            
            yield return null;
        }
    }
    IEnumerator GradualPlayerHealthIncrease(float newHp)
    {
        while (playerHpImage.fillAmount <= newHp)
        {
            playerHpImage.fillAmount += 0.01f;
            yield return null;
        }
    }
    IEnumerator FlickerPlayerHitImage ()
    {
        while (count < 3)
        {
            count++;
            activeToggle = !activeToggle;
            playerHitImage.gameObject.SetActive(activeToggle);
            yield return new WaitForSeconds(0.3f);
        }
        playerHitImage.gameObject.SetActive(false);
        StopCoroutine("FlickerPlayerHitImage");
    }

    IEnumerator FlickerEnemyHitImage ()
    {
        while (count < 3)
        {
            count++;
            activeToggle = !activeToggle;
            enemyHitImage.gameObject.SetActive(activeToggle);
            yield return new WaitForSeconds(0.3f);
        }
        enemyHitImage.gameObject.SetActive(false);
        StopCoroutine("FlickerEnemyHitImage");
    }
}