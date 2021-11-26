using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public int level;
    
    private PlayerController playerController;
    public GameObject player;
    public GameObject lampa;

    private void Start()
    {
        lampa = GameObject.FindGameObjectWithTag("Light5");
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneToLoad.ChangeLevelToLoad(level);
        }
        else if (playerController.electricalCompleted)
        {
            lampa.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
