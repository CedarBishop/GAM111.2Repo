using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    BattleLogic battleLogic;
    public string enemyAttackName;
    TMPro.TextMeshProUGUI enemyAttackText;
    public float damageEnemyDeals = 25;
    // Start is called before the first frame update
    
    public void AttackPlayer ()
    {
        enemyAttackText = GameObject.Find("Enemy Attack Text").GetComponent<TMPro.TextMeshProUGUI>();
        enemyAttackText.text = enemyAttackName;
    }

    public void EnemyAttackDamageStep ()
    {
        battleLogic = GameObject.Find("Scene Manager").GetComponent<BattleLogic>();
        battleLogic.PlayerTakeDamage(damageEnemyDeals);

    }
    public void ClearEnemyAttackText ()
    {
        enemyAttackText = GameObject.Find("Enemy Attack Text").GetComponent<TMPro.TextMeshProUGUI>();
        enemyAttackText.text = "";
    }
}
