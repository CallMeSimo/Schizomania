using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    private float timer = 0f;

    private Component halo;

    private bool insideCol = false;
    public bool fårBlinka = false;


    // Start is called before the first frame update

    void Start()
    {
        halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }
    // Update is called once per frame
    void Update()
    {
        if (fårBlinka)
        {
            Blinka();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            insideCol = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
            insideCol = false;
        }
    }
    void Blinka()
    {
        if (insideCol)
        {
            timer += Time.deltaTime;
            if (timer <= 0.5f)
            {
                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                Debug.Log(timer);
            }

            if (timer >= 1f)
            {
                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                Debug.Log("2");
            }

            if (timer >= 2f)
            {
                timer -= timer;
                Debug.Log("3");
            }

        }
    }


}





