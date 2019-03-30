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
    void Start()
    {
        battleLogic = GameObject.Find("Scene Manager").GetComponent<BattleLogic>();
        enemyAttackText = GameObject.Find("Enemy Attack Text").GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void AttackPlayer ()
    {
        enemyAttackText.text = enemyAttackName;
    }

    public void EnemyAttackDamageStep ()
    {
        battleLogic.PlayerTakeDamage(damageEnemyDeals);

    }
    public void ClearEnemyAttackText ()
    {
        enemyAttackText.text = "";
    }
}
