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
    public void FirePunch ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Player used Fire Punch!";
    }

    public void SweepKick ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Player used Sweep Kick!";
    }

    public void IceTornado ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Player used Ice Tornado!";
    }

    public void Heal ()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerCurrentAttackText.text = "Player used Heal!";
    }


}
