using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    public int Number;
    public bool FloorContact;

    // Start is called before the first frame update
    void Start()
    {
        Number = int.Parse(GetComponent<TextMesh>().text);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            FloorContact = true;
        }
    }

    void OnTriggerExit(Collider col)

    {
        FloorContact = false;
    }
       
 


}

    




