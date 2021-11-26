using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalMinigame : MonoBehaviour
{
    public int level;
    private GameObject blink1;
    private GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        blink1 = GameObject.FindGameObjectWithTag("Light1");
        blink1.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!playerController.electricalCompleted)
            {
                blink1.SetActive(true);
               
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            blink1.SetActive(false);
        }
        else if (playerController.electricalCompleted)
        {
            blink1.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !playerController.clockCompleted)
        {
            SceneToLoad.ChangeLevelToLoad(level);
            playerController.HidePlayerOnLoad();
        }
    }
}
