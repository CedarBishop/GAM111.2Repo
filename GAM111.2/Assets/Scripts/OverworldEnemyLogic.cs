using UnityEngine;

public class OverworldEnemyLogic : MonoBehaviour
{
    private GameObject[] chickens;
    private GameObject[] ducks;
    private GameObject[] pigs;
    private float timer;
    public float timeBeforeTypeRespawns;
    bool[] enemyRespawnTimerStatus = { false, false, false };
    void Start()
    {
        chickens = GameObject.FindGameObjectsWithTag("Enemy1");
        foreach (GameObject chicken in chickens)
        {
            chicken.SetActive(GameManager.instance.retrieveEnemyStatus(1));
            enemyRespawnTimerStatus[0] = true;            
        }

        ducks = GameObject.FindGameObjectsWithTag("Enemy2");
        foreach (GameObject duck in ducks)
        {
            duck.SetActive(GameManager.instance.retrieveEnemyStatus(3));
            enemyRespawnTimerStatus[1] = true;
        }

        pigs = GameObject.FindGameObjectsWithTag("Enemy3");
        foreach (GameObject pig in pigs)
        {
            pig.SetActive(GameManager.instance.retrieveEnemyStatus(3));
            enemyRespawnTimerStatus[2] = true;
        }
        timer = timeBeforeTypeRespawns;
    }

    void Update()
    {
        if (timer <= 0 && enemyRespawnTimerStatus[0] == true)
        {
            foreach (GameObject chicken in chickens)
            {
                chicken.SetActive(true);
            }
            enemyRespawnTimerStatus[0] = false;
        }
        else if (timer <= 0 && enemyRespawnTimerStatus[1] == true)
        {
            foreach (GameObject duck in ducks)
            {
                duck.SetActive(true);
            }
            enemyRespawnTimerStatus[1] = false;
        }
        else if (timer <= 0 && enemyRespawnTimerStatus[2] == true)
        {
            foreach (GameObject pig in pigs)
            {
                pig.SetActive(true);
            }
            enemyRespawnTimerStatus[2] = false;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
