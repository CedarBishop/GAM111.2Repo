using System.Collections;
using UnityEngine;

public class TurnBasedSystem : MonoBehaviour
{
    EnemyAttacks enemyAttacks;
    public Canvas buttonCanvas;
    public enum CurrentAnimalTurn { PlayerSelection ,PlayerAttack, PlayerDamage, EnemySelection, EnemyAttack, EnemyDamage};
    public CurrentAnimalTurn currentAnimalTurn;
    public PlayerAttacks playerAttacks;
    void Start()
    {
        if (GameManager.instance.ReturnEnemyType() == 1)
        {
            enemyAttacks = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<EnemyAttacks>();
        }
        else if (GameManager.instance.ReturnEnemyType() == 2)
        {
            enemyAttacks = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<EnemyAttacks>();
        }
        else if (GameManager.instance.ReturnEnemyType() == 3)
        {
            enemyAttacks = GameObject.FindGameObjectWithTag("Enemy3").GetComponent<EnemyAttacks>();
        }
        currentAnimalTurn = CurrentAnimalTurn.PlayerSelection;
    }   


    public void InvokeCycle ()
    {
        switch (currentAnimalTurn)
        {
            case CurrentAnimalTurn.PlayerSelection:
                break;
            case CurrentAnimalTurn.PlayerAttack:
                StartCoroutine("CycleNextTurn");
                break;
            case CurrentAnimalTurn.PlayerDamage:
                StartCoroutine("CycleNextTurn");
                break;
            case CurrentAnimalTurn.EnemySelection:
                StartCoroutine("CycleNextTurn");
                break;
            case CurrentAnimalTurn.EnemyAttack:
                StartCoroutine("CycleNextTurn");
                break;
            case CurrentAnimalTurn.EnemyDamage:
                StartCoroutine("CycleNextTurn");
                break;
            default:
                break;
        }

    }

    public IEnumerator CycleNextTurn ()
    {
        switch (currentAnimalTurn)
        {
            case CurrentAnimalTurn.PlayerSelection:
                Debug.Log("1");
                yield return new WaitForSeconds(0);
                buttonCanvas.gameObject.SetActive(false);
                currentAnimalTurn = CurrentAnimalTurn.PlayerAttack;
                break;
            case CurrentAnimalTurn.PlayerAttack:
                Debug.Log("2");
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.PlayerDamage;
                break;
            case CurrentAnimalTurn.PlayerDamage:
                Debug.Log("3");               
                playerAttacks.PlayerAttackDamage();
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemySelection;
                break;
            case CurrentAnimalTurn.EnemySelection:
                Debug.Log("4");
                playerAttacks.ClearPlayerAttackText();
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemyAttack;
                break;
            case CurrentAnimalTurn.EnemyAttack:
                Debug.Log("5");
                enemyAttacks.AttackPlayer();
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemyDamage;
                break;
            case CurrentAnimalTurn.EnemyDamage:
                Debug.Log("6");                
                enemyAttacks.EnemyAttackDamageStep();
                yield return new WaitForSeconds(2);
                buttonCanvas.gameObject.SetActive(true);
                enemyAttacks.ClearEnemyAttackText();
                currentAnimalTurn = CurrentAnimalTurn.PlayerSelection;
                break;
            default:
                break;
        }
        StopCoroutine("CycleNextTurn");
        InvokeCycle();
    }
}
