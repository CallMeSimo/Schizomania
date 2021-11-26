using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KlockanScript : MonoBehaviour
{
    public int level = 1;
    private bool inCollider;

    private GameObject player;
    private PlayerController playerController;

    public GameObject blink;
    public bool canBlink;

    private void Start()
    {
        blink.SetActive(false);
        player = FindInActiveObjectByName("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!playerController.clockCompleted && canBlink)
            {
                blink.SetActive(true);
                inCollider = true;
            } else
            {
                return;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playerController.clockCompleted)
        {
            return;
        }
        else
        {
            blink.SetActive(false);
            inCollider = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inCollider && !playerController.clockCompleted)
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
