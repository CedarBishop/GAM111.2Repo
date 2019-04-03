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
    public Animator enemyAnim;
    //public GameObject[] attackParticles;
    
    public void AttackPlayer ()
    {
        randomIndex = Random.Range(0,enemyAttackNames.Length);

        enemyAttackText = GameObject.Find("Enemy Attack Text").GetComponent<TMPro.TextMeshProUGUI>();
        enemyAttackText.text = enemyName + " used " + enemyAttackNames[randomIndex];
        SoundManager.instance.RandomizePitchAndPlay(enemyAttackSounds[randomIndex]);
        enemyAnim.SetTrigger("enemyAttacks");
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
        //GameObject go = Instantiate(attackParticles[randomIndex],new Vector3(0, 0,  0), Quaternion.identity);
        //Destroy(go,2);
    }
    public void ClearEnemyAttackText ()
    {
        enemyAttackText = GameObject.Find("Enemy Attack Text").GetComponent<TMPro.TextMeshProUGUI>();
        enemyAttackText.text = "";
    }

    public void EnemyFainted ()
    {
        enemyAttackText.text = enemyName + " has fainted";
        enemyAnim.SetBool("enemyIsDead", true);
    }
}
