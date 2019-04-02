using System.Collections;
using UnityEngine;

public class OverworldEnemyLogic : MonoBehaviour
{
    private GameObject chicken;
    private GameObject duck;
    private GameObject pig;
    public float timeBeforeRespawn;
    
    void Start()
    {
        chicken = GameObject.FindGameObjectWithTag("Enemy1");        
        chicken.SetActive(GameManager.instance.retrieveEnemyStatus(1));    

        duck = GameObject.FindGameObjectWithTag("Enemy2");      
        duck.SetActive(GameManager.instance.retrieveEnemyStatus(2));

        pig = GameObject.FindGameObjectWithTag("Enemy3");        
        pig.SetActive(GameManager.instance.retrieveEnemyStatus(3));
        StartCoroutine("TimeBeforeRespawn");
    }

    IEnumerator TimeBeforeRespawn ()
    {
        yield return new WaitForSeconds(timeBeforeRespawn);
        chicken.SetActive(true);
        duck.SetActive(true);
        pig.SetActive(true);
    }

   
}
