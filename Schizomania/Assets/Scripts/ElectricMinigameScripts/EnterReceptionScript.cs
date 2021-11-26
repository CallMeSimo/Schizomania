using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterReceptionScript : MonoBehaviour
{
    public int level;
    private bool onCollider;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Trigger");
            onCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onCollider = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onCollider)
        {
            SceneToLoad.ChangeLevelToLoad(level);
        }
    }
}
