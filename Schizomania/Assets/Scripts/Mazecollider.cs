using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazecollider : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        Debug.Log("helo");
    }


    private void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Debug.Log("du Träffa väggen");
            SceneToLoad.ChangeLevelToLoad(4);

        }

    }
}
