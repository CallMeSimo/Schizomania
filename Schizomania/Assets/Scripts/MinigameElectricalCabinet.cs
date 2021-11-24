using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MinigameElectricalCabinet : MonoBehaviour
{
    private bool inCollider;

    private GameObject player;
    private GameObject blink1;
    private PlayerController playerController;

    public int level;


    private void Start()
    {
        blink1 = GameObject.FindGameObjectWithTag("Light");
        blink1.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
   

        ////Testar ändra itensiteten i lampan
        //blink2.GetComponent<Light>().intensity = 3;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(!playerController.electricalCompleted)
            {

            blink1.SetActive(true);
            inCollider = true;

            }
            else
            {
                return;
            }

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            blink1.SetActive(false);
            inCollider = false;

        }

        if (playerController.electricalCompleted)
        {
            blink1.SetActive(false);
            inCollider = false;
        }
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inCollider && !playerController.electricalCompleted)
        {
            SceneToLoad.ChangeLevelToLoad(level);
            playerController.HidePlayerOnLoad();
        }
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

}