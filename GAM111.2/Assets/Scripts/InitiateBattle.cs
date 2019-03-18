using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateBattle : MonoBehaviour
{
    public string battleSceneNames;
   
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
        GameManager.instance.StoreEnemyToFight(enemyType);
        SceneManager.LoadScene(battleSceneNames);
    }
}
