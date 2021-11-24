using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupObjects : MonoBehaviour
{
    private bool inCollider;

    private GameObject player;
    private PlayerController playerController;

    private GameObject blink2;
    private GameObject bultsax;

    private bool pickUp = false;
    

    private void Start()
    {
        blink2 = GameObject.FindGameObjectWithTag("Light");
        bultsax = GameObject.FindGameObjectWithTag("Bultsax");
     


        blink2.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        ////Testar ändra itensiteten i lampan
        //blink2.GetComponent<Light>().intensity = 3;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            blink2.SetActive(true);
            inCollider = true;
            PickUp();
  
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            blink2.SetActive(false);
            inCollider = false;
        }
    }

    void PickUp()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Destroy");
            pickUp = true;
            Destroy(bultsax);
        }
    }


}





