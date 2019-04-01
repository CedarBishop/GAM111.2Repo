using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateBattle : MonoBehaviour
{
    public string battleScene;
    OverworldHealth overworldHealth;
    Transform playerTransform;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy1"))
        {
            SwitchToBattleScene(1);
        }
        else if (other.gameObject.CompareTag("Enemy2"))
        {
            SwitchToBattleScene(2);
        }
        else if (other.gameObject.CompareTag("Enemy3"))
        {
            SwitchToBattleScene(3);
        }
    }

    void SwitchToBattleScene(int enemyType)
    {
        overworldHealth = GameObject.Find("Scene Manager").GetComponent<OverworldHealth>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SoundManager.instance.StartCoroutine("CrossFadeToBattle");
        GameManager.instance.StoreHealth(overworldHealth.healthBar.fillAmount);
        GameManager.instance.StorePosition(playerTransform.position);
        GameManager.instance.StoreEnemyToFight(enemyType);
        SceneManager.LoadScene(battleScene);
    }
}
