using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionistDetection : MonoBehaviour
{
    public bool lampaOn; 
    public GameObject Receptionist;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && lampaOn==true)
        {
           Debug.Log ("du blev hittad av receptionisten");

        }

      else  if (collision.tag == "Player" && lampaOn==false)
        {
            Debug.Log("recetprionsten kan inte se dig");
        }
    }
}
