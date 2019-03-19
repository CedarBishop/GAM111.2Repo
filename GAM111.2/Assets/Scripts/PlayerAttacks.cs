using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    public Canvas buttonCanvas;
    public TMPro.TextMeshProUGUI playerCurrentAttackText;
    void Start ()
    {
        playerCurrentAttackText.text = "";
    }
    public void Schnitzel ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Big Mac used Schnitzel!";
    }

    public void Fry ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Big Mac used Fry!";
    }

    public void Roast ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Big Mac used Roast!";
    }

    public void EatGrass ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Big Mac used Eat Grass!";
    }


}
