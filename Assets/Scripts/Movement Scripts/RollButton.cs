using UnityEngine;
using UnityEngine.UI;

public class RollButton : MonoBehaviour
{
    public Dice dice;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(RollDice);
    }

    void RollDice()
    {
        dice.RollDice();
    }
}

