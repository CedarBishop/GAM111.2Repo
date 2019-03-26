using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private float healthAtTransistion = 1;
    private int enemyToFace;

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
    }

    public int ReturnEnemyType ()
    {
        return enemyToFace;
    }
}
