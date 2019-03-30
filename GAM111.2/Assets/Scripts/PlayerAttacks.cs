﻿using UnityEngine;
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
        battleLogic = GameObject.Find("Scene Manager").GetComponent<BattleLogic>();
        buttonCanvas.gameObject.SetActive(true);
        turnBasedSystem = GameObject.Find("Scene Manager").GetComponent<TurnBasedSystem>();
    }

    public void Schnitzel ()
    {
        playerCurrentAttackText.text = "Big Mac used Schnitzel!";
        attackBeingUsed = "Schnitzel";
        turnBasedSystem.StartCoroutine("CycleNextTurn");
    }

    public void Fry ()
    {
        playerCurrentAttackText.text = "Big Mac used Fry!";
        attackBeingUsed = "Fry";
        turnBasedSystem.StartCoroutine("CycleNextTurn");

    }

    public void Roast ()
    {
        playerCurrentAttackText.text = "Big Mac used Roast!";
        attackBeingUsed = "Roast";
        turnBasedSystem.StartCoroutine("CycleNextTurn");
    }

    public void EatGrass ()
    {
        playerCurrentAttackText.text = "Big Mac used Eat Grass!";
        attackBeingUsed = "EatGrass";
        turnBasedSystem.StartCoroutine("CycleNextTurn");
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
       // turnBasedSystem.StartCoroutine("CycleNextTurn");
    }
    public void ClearPlayerAttackText()
    {
        playerCurrentAttackText.text = "";
    }
}
