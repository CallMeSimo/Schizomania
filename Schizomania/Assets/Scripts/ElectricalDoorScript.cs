using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool doorUnlocked = false;


    private bool canOpenDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindInActiveObjectByName("Player");
        playerController = player.GetComponent<PlayerController>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && doorUnlocked)
        {
            Destroy(gameObject);
            SceneToLoad.ChangeLevelToLoad(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorUnlocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorUnlocked = false;
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