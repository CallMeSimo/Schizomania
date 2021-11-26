using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject health1, health2, health3, gameOver;
    public static int health = 3;
    // Start is called before the first frame update
    void Start()
    {
    //    health = 3;
    //    health1.gameObject.SetActive(true);
    //    health2.gameObject.SetActive(true);
    //    health3.gameObject.SetActive(true);
    //    gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
        {
            health = 3;
        }

            switch (health)
            {
                case 3:
                    health1.gameObject.SetActive(true);
                    health2.gameObject.SetActive(true);
                    health3.gameObject.SetActive(true);
                    break;

                case 2:
                    health1.gameObject.SetActive(true);
                    health2.gameObject.SetActive(true);
                    health3.gameObject.SetActive(false);
                    break;

                case 1:
                    health1.gameObject.SetActive(true);
                    health2.gameObject.SetActive(false);
                    health3.gameObject.SetActive(false);
                    break;

                case 0:
                    health1.gameObject.SetActive(false);
                    health2.gameObject.SetActive(false);
                    health3.gameObject.SetActive(false);
                    SceneToLoad.ChangeLevelToLoad(0);
                    Time.timeScale = 0;
                    break;


            }

    }
}
