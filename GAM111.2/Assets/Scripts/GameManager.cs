using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private float healthAtTransistion = 1;
    private int enemyToFace;
    private Vector3 playerCurrentPosition = new Vector3(-20,0.6f,0);
    private bool[] enemyIsAlive = {true, true, true};

    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void StoreHealth (float currentHealth)
    {        
        healthAtTransistion = currentHealth;        
    }
    public float RetrieveHealth ()
    {
        return healthAtTransistion;
    }
    public void StoreEnemyToFight (int enemyType)
    {
        enemyToFace = enemyType;
        enemyIsAlive[enemyType - 1] = false;
    }

    public int ReturnEnemyType ()
    {
        return enemyToFace;
    }

    public void StorePosition (Vector3 currentPosition)
    {
        playerCurrentPosition = currentPosition;
    }

    public Vector3 RetrievePosition ()
    {
        return playerCurrentPosition;
    }

    public bool retrieveEnemyStatus (int enemyType)
    {
        return enemyIsAlive[enemyType - 1];
    }    
}