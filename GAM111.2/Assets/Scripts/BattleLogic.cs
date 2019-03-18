using UnityEngine;
using UnityEngine.UI;

public class BattleLogic : MonoBehaviour
{
    public Image playerHpImage;
    public Image enemyHpImage;
    public Text playerHpText;
    public Text enemyHpText;
    public TMPro.TextMeshProUGUI enemyName;

    void Start()
    {
        FindEnemyName();
    }

    void Update()
    {
        playerHpText.text = "HP: " + (playerHpImage.fillAmount * 100).ToString("F0");
        enemyHpText.text = "HP: " + (enemyHpImage.fillAmount * 100).ToString("F0");
    }

    void FindEnemyName ()
    {
        if (GameManager.instance.ReturnEnemyType() == 1)
        {
            enemyName.text = "Enemy 1";
        }
        else if (GameManager.instance.ReturnEnemyType() == 2)
        {
            enemyName.text = "Enemy 2";
        }
        else if (GameManager.instance.ReturnEnemyType() == 3)
        {
            enemyName.text = "Enemy 3";
        }
    }
}
