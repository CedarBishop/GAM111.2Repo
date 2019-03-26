using System.Collections;
using UnityEngine;

public class TurnBasedSystem : MonoBehaviour
{
    public Canvas buttonCanvas;
    public enum CurrentAnimalTurn { PlayerSelection ,PlayerAttack, PlayerDamage, EnemySelection, EnemyAttack, EnemyDamage};
    public CurrentAnimalTurn currentAnimalTurn;
    void Start()
    {
        currentAnimalTurn = CurrentAnimalTurn.PlayerSelection;
    }   

    public IEnumerator CycleNextTurn ()
    {
        switch (currentAnimalTurn)
        {
            case CurrentAnimalTurn.PlayerSelection:
                yield return new WaitForSeconds(0);
                buttonCanvas.gameObject.SetActive(false);
                currentAnimalTurn = CurrentAnimalTurn.PlayerAttack;
                break;
            case CurrentAnimalTurn.PlayerAttack:
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.PlayerDamage;
                break;
            case CurrentAnimalTurn.PlayerDamage:
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemySelection;
                break;
            case CurrentAnimalTurn.EnemySelection:
                yield return new WaitForSeconds(0);
                currentAnimalTurn = CurrentAnimalTurn.PlayerAttack;
                break;
            case CurrentAnimalTurn.EnemyAttack:
                yield return new WaitForSeconds(2);
                currentAnimalTurn = CurrentAnimalTurn.EnemyDamage;
                break;
            case CurrentAnimalTurn.EnemyDamage:
                yield return new WaitForSeconds(2);
                buttonCanvas.gameObject.SetActive(true);
                currentAnimalTurn = CurrentAnimalTurn.PlayerSelection;
                break;
            default:
                break;
        }
        StopCoroutine("CycleNextTurn");
    }
}
