using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{

    public Text text;
    public Side[] Sides;
    public int CurrentNumber;


    // Start is called before the first frame update
    void Start()
    {
        DiceNumber(); 
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 extraForce = new Vector3(-100f, 0, 0); // Example extra force
        rb.AddForce(extraForce, ForceMode.Impulse);
    }



    // Update is called once per frame
    void Update()
    {
        text.text = "Number: " + CurrentNumber;

    }


    void DiceNumber()
    {
        for (int i = 0; i < Sides.Length; i++)
        {
            if (Sides[i].FloorContact)
            {
                CurrentNumber = 7 - Sides[i].Number;

            }


        }

        Invoke("DiceNumber", 0.5f);

    }

    public void RollDice()
    {

        float initialImpulse = Random.Range(1, 6);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, initialImpulse * 100, 0));
        GetComponent<Rigidbody>().rotation = Random.rotation;

    }
}

