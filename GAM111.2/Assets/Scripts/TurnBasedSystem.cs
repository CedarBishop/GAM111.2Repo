using UnityEngine;

public class TurnBasedSystem : MonoBehaviour
{
    public enum CurrentAnimalTurn { Player, Enemy, None};
    CurrentAnimalTurn currentAnimalTurn;
    [HideInInspector] public static bool playersTurn;
    [HideInInspector] public static bool enemiesTurn;

    void Start()
    {
        currentAnimalTurn = CurrentAnimalTurn.Player;
    }


    void Update()
    {
        switch (currentAnimalTurn)
        {
            case CurrentAnimalTurn.Player:
                playersTurn = true;
                enemiesTurn = false;
                break;
            case CurrentAnimalTurn.Enemy:
                playersTurn = false;
                enemiesTurn = true;
                break;
            case CurrentAnimalTurn.None:
                playersTurn = false;
                enemiesTurn = false;
                break;
        }
    }

    public void CycleNextTurn ()
    {
        switch (currentAnimalTurn)
        {
            case CurrentAnimalTurn.Player:
                currentAnimalTurn = CurrentAnimalTurn.Enemy;
                break;
            case CurrentAnimalTurn.Enemy:
                currentAnimalTurn = CurrentAnimalTurn.None;
                break;
            case CurrentAnimalTurn.None:
                currentAnimalTurn = CurrentAnimalTurn.Player;
                break;
        }
    }
}
