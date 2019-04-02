using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    BattleLogic battleLogic;
    public string[] enemyAttackNames;
    TMPro.TextMeshProUGUI enemyAttackText;
    public float[] damageEnemyDeal;
    int randomIndex;
    public string enemyName;
    public AudioClip[] enemyAttackSounds;
    
    public void AttackPlayer ()
    {
        randomIndex = Random.Range(0,enemyAttackNames.Length);

        enemyAttackText = GameObject.Find("Enemy Attack Text").GetComponent<TMPro.TextMeshProUGUI>();
        enemyAttackText.text = enemyName + " used " + enemyAttackNames[randomIndex];
        SoundManager.instance.RandomizePitchAndPlay(enemyAttackSounds[randomIndex]);
    }

    public void EnemyAttackDamageStep ()
    {
        battleLogic = GameObject.Find("Scene Manager").GetComponent<BattleLogic>();
        switch (randomIndex)
        {
            case 0:
                enemyAttackText.text = enemyAttackNames[randomIndex] + " was super effective";
                break;
            case 1:
                enemyAttackText.text = "";
                break;
            case 2:
                enemyAttackText.text = enemyAttackNames[randomIndex] + " was not very effective";
                break;
            default:
                break;
        }
        battleLogic.PlayerTakeDamage(damageEnemyDeal[randomIndex]);

    }
    public void ClearEnemyAttackText ()
    {
        enemyAttackText = GameObject.Find("Enemy Attack Text").GetComponent<TMPro.TextMeshProUGUI>();
        enemyAttackText.text = "";
    }
}
