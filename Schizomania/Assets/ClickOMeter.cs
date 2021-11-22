using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOMeter : MonoBehaviour
{
    public float speed;
    public float pullSpeed;
    public float markiplier;
    public GameObject start;
    private float calculatedSpeed;
    private float lastSteps, timeBetweenSteps = 0.05f;
    public int cellLevel;

    private GameObject player;
    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        calculatedSpeed = speed;

        player = FindInActiveObjectByName("Player");
        playerController = player.GetComponent<PlayerController>();
  

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * pullSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.time - lastSteps > timeBetweenSteps)
            {
                lastSteps = Time.time;
                transform.Translate(Vector2.left * calculatedSpeed * Time.deltaTime);
                calculatedSpeed = speed - Vector2.Distance(start.transform.position, transform.position) * markiplier; // PEMDAS
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "End")
        {
            SceneManager.LoadScene(cellLevel);
            playerController.ShowPlayerOnLoad();
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
