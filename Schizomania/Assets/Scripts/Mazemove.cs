using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazemove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SpeedBoost")
        {
            speed = 6f;
        }

         if (collision.gameObject.name == "SpeedBoost2")
        {
            speed = 13f;
        }

         if(collision.gameObject.name == "End")
        {
            SceneToLoad.ChangeLevelToLoad(2);
        }
    }
}
