using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject klocka;
    private KlockanScript klockanScript;

    private GameObject player;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    private bool canOpenDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindInActiveObjectByName("Player");
        playerController = player.GetComponent<PlayerController>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();

        klocka = FindInActiveObjectByName("klocka");
        // klockanScript = klocka.GetComponent<KlockanScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenDoor)
        {
            spriteRenderer.color = new Color(0, 0, 0, 255);
            Debug.Log("Thanks for playing!");
            Destroy(gameObject);
            SceneToLoad.ChangeLevelToLoad(2);
        }    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.gameObject.tag == "Player")
        {
            if (playerController.clockCompleted)
            {
                canOpenDoor = true;
            }

            klockanScript.canBlink = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerController.clockCompleted)
            {
                canOpenDoor = false;
            }
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
