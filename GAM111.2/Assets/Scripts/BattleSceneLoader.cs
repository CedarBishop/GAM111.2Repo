using UnityEngine;
using UnityEngine.UI;

public class BattleSceneLoader : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform enemySpawnPoint;
    public Image healthBar;
    GameObject go;

    void Start()
    {
        go = Instantiate(enemyPrefabs[GameManager.instance.ReturnEnemyType() - 1],enemySpawnPoint.position, enemySpawnPoint.rotation);
        healthBar.fillAmount = GameManager.instance.RetrieveHealth();
    }
}
