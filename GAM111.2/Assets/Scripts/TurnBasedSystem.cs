using System.Collections;
using UnityEngine;

public class TurnBasedSystem : MonoBehaviour
{
    EnemyAttacks enemyAttacks;
    public enum CurrentAnimalTurn {PlayerSelection ,PlayerAttack, PlayerDamage, EnemySelection, EnemyAttack, EnemyDamage};
    public CurrentAnimalTurn currentAnimalTurn;
    public PlayerAttacks playerAttacks;
    public Canvas[] allCanvas;
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
        StartCoroutine("TimeDelayAtStartOfBattle");
        foreach (Canvas canvas in allCanvas)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    IEnumerator TimeDelayAtStartOfBattle()
    {        
        yield return new WaitForSeconds(2);        
        foreach  (Canvas canvas in allCanvas)
        {
            canvas.gameObject.SetActive(true);
        }
        StopCoroutine("TimeDelayAtStartOfBattle");
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
                yield return new WaitForSeconds(0);
                playerAttacks.TurnOffButtons();
                currentAnimalTurn = CurrentAnimalTurn.PlayerAttack;
                break;
            case CurrentAnimalTurn.PlayerAttack:
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.PlayerDamage;
                break;
            case CurrentAnimalTurn.PlayerDamage:              
                playerAttacks.PlayerAttackDamage();
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemySelection;
                break;
            case CurrentAnimalTurn.EnemySelection:
                playerAttacks.ClearPlayerAttackText();
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemyAttack;
                break;
            case CurrentAnimalTurn.EnemyAttack:
                enemyAttacks.AttackPlayer();
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemyDamage;
                break;
            case CurrentAnimalTurn.EnemyDamage:          
                enemyAttacks.EnemyAttackDamageStep();
                yield return new WaitForSeconds(2);
                playerAttacks.TurnOnButtons();
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
