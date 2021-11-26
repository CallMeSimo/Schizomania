using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterractableObject : MonoBehaviour
{
    public GameObject lightSource;
    private PlayerController playerController;

    private bool insideCol = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && insideCol)
        {
            DoThisWhenPressed();
        }

        if (insideCol)
        {
            lightSource.SetActive(true);
        }
        else if (!insideCol)
        {
            lightSource.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerController = collision.GetComponent<PlayerController>();
            insideCol = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            insideCol = false;
        }
    }

    void DoThisWhenPressed()
    {
        if (gameObject.tag == "Pickup")
        {
            playerController.AddItemToInventory(gameObject.name);
            Debug.Log("Bultsaxen har plockats upp");
            Destroy(gameObject);
        }

        else if (gameObject.tag == "NonPickup")
        {
            switch (gameObject.name)
            {
                case "Clock":
                    SceneToLoad.ChangeLevelToLoad(1);
                    break;

                case "ElectricalGame":
                    SceneToLoad.ChangeLevelToLoad(1);
                    break;

                case "BasementGame":
                    SceneToLoad.ChangeLevelToLoad(1);
                    break;
            }
            playerController.HidePlayerOnLoad();
        }
    }
}





