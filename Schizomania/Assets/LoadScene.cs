using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int Level;
    private bool inCollider;

    private GameObject player;
    private PlayerController playerController;

    private void Start()
    {
        player = FindInActiveObjectByName("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("True");
            inCollider = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("False");
            inCollider = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& inCollider)
        {
            SceneManager.LoadScene(Level);
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
