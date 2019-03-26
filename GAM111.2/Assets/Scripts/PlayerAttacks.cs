using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    TurnBasedSystem turnBasedSystem;
    BattleLogic battleLogic;
    public Canvas buttonCanvas;
    public TMPro.TextMeshProUGUI playerCurrentAttackText;
    string attackBeingUsed;
    void Start ()
    {
        playerCurrentAttackText.text = "";
        battleLogic = GetComponent<BattleLogic>();

    }

    public void Schnitzel ()
    {
        turnBasedSystem.CycleNextTurn();
        playerCurrentAttackText.text = "Big Mac used Schnitzel!";
        attackBeingUsed = "Schnitzel";
    }

    public void Fry ()
    {
        turnBasedSystem.CycleNextTurn();
        playerCurrentAttackText.text = "Big Mac used Fry!";
        attackBeingUsed = "Fry";

    }

    public void Roast ()
    {
        turnBasedSystem.CycleNextTurn();
        playerCurrentAttackText.text = "Big Mac used Roast!";
        attackBeingUsed = "Roast";
    }

    public void EatGrass ()
    {
        turnBasedSystem.CycleNextTurn();
        playerCurrentAttackText.text = "Big Mac used Eat Grass!";
        attackBeingUsed = "EatGrass";
    }
    
	public void PlayerAttackDamage()
    {
        if (attackBeingUsed == "Schnitzel" && GameManager.instance.ReturnEnemyType() == 1)
        {
            playerCurrentAttackText.text = "Schnitzel was Super Effective";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Schnitzel" && GameManager.instance.ReturnEnemyType() == 2)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Schnitzel" && GameManager.instance.ReturnEnemyType() == 3)
        {
            playerCurrentAttackText.text = "Schnitzel was not very effective";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Fry" && GameManager.instance.ReturnEnemyType() == 1)
        {
            playerCurrentAttackText.text = "Fry was not very effective";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Fry" && GameManager.instance.ReturnEnemyType() == 2)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Fry" && GameManager.instance.ReturnEnemyType() == 3)
        {
            playerCurrentAttackText.text = "Fry was super effective";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Roast" && GameManager.instance.ReturnEnemyType() == 1)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Roast" && GameManager.instance.ReturnEnemyType() == 2)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "Roast" && GameManager.instance.ReturnEnemyType() == 3)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(50.0f);
        }
        else if (attackBeingUsed == "EatGrass")
        {
            battleLogic.PlayerHeals(40.0f);
        }
    }
}
