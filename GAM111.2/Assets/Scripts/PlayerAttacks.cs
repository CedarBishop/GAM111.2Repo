using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    TurnBasedSystem turnBasedSystem;
    BattleLogic battleLogic;
    public Canvas buttonCanvas;
    public TMPro.TextMeshProUGUI playerCurrentAttackText;
    string attackBeingUsed;
    public Animator playerAnim;
    void Start ()
    {
        playerCurrentAttackText.text = "";
        battleLogic = GameObject.Find("Scene Manager").GetComponent<BattleLogic>();
        buttonCanvas.gameObject.SetActive(false);
        turnBasedSystem = GameObject.Find("Scene Manager").GetComponent<TurnBasedSystem>();
    }

    public void Schnitzel ()
    {
        playerCurrentAttackText.text = "Big Mac used Schnitzel!";
        attackBeingUsed = "Schnitzel";
        turnBasedSystem.StartCoroutine("CycleNextTurn");
        playerAnim.SetTrigger("playerAttacks");
    }

    public void Fry ()
    {
        playerCurrentAttackText.text = "Big Mac used Braise!";
        attackBeingUsed = "Braise";
        turnBasedSystem.StartCoroutine("CycleNextTurn");
        playerAnim.SetTrigger("playerAttacks");
    }

    public void Roast ()
    {
        playerCurrentAttackText.text = "Big Mac used Roast!";
        attackBeingUsed = "Roast";
        turnBasedSystem.StartCoroutine("CycleNextTurn");
        playerAnim.SetTrigger("playerAttacks");
    }

    public void EatGrass ()
    {
        playerCurrentAttackText.text = "Big Mac used Eat Grass!";
        attackBeingUsed = "EatGrass";
        turnBasedSystem.StartCoroutine("CycleNextTurn");
        playerAnim.SetTrigger("playerHeals");
    }
    
	public void PlayerAttackDamage()
    {
        if (attackBeingUsed == "Schnitzel" && GameManager.instance.ReturnEnemyType() == 1)
        {
            playerCurrentAttackText.text = "Schnitzel was Super Effective";
            battleLogic.EnemyTakeDamage(49);
        }
        else if (attackBeingUsed == "Schnitzel" && GameManager.instance.ReturnEnemyType() == 2)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(33);
        }
        else if (attackBeingUsed == "Schnitzel" && GameManager.instance.ReturnEnemyType() == 3)
        {
            playerCurrentAttackText.text = "Schnitzel was not very effective";
            battleLogic.EnemyTakeDamage(24);
        }
        else if (attackBeingUsed == "Braise" && GameManager.instance.ReturnEnemyType() == 1)
        {
            playerCurrentAttackText.text = "Braise was not very effective";
            battleLogic.EnemyTakeDamage(24);
        }
        else if (attackBeingUsed == "Braise" && GameManager.instance.ReturnEnemyType() == 2)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(33);
        }
        else if (attackBeingUsed == "Braise" && GameManager.instance.ReturnEnemyType() == 3)
        {
            playerCurrentAttackText.text = "Braise was super effective";
            battleLogic.EnemyTakeDamage(49);
        }
        else if (attackBeingUsed == "Roast" && GameManager.instance.ReturnEnemyType() == 1)
        {
            playerCurrentAttackText.text = "";
            battleLogic.EnemyTakeDamage(33);
        }
        else if (attackBeingUsed == "Roast" && GameManager.instance.ReturnEnemyType() == 2)
        {
            playerCurrentAttackText.text = "Roast was super effective";
            battleLogic.EnemyTakeDamage(49);
        }
        else if (attackBeingUsed == "Roast" && GameManager.instance.ReturnEnemyType() == 3)
        {
            playerCurrentAttackText.text = "Roast was not very effective";
            battleLogic.EnemyTakeDamage(24);
        }
        else if (attackBeingUsed == "EatGrass")
        {
            battleLogic.PlayerHeals(39.0f);
        }
    }
    public void ClearPlayerAttackText()
    {
        playerCurrentAttackText.text = "";
    }

    public void TurnOnButtons()
    {
        buttonCanvas.gameObject.SetActive(true);
    }
    public void TurnOffButtons()
    {
        buttonCanvas.gameObject.SetActive(false);
    }
}
