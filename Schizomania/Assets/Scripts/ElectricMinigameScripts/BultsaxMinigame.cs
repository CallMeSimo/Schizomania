using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BultsaxMinigame : MonoBehaviour
{
    public int level;
    public float height = 10f;
    public float yCenter = 10f;


    private GameObject yellowCable;
    private GameObject pinkCable;
    private GameObject blueCable;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController playerController;
    private GameObject lightScript;

    private PinkCable pinkWire;
    private BlueCable blueWire;
    private YellowCable yellowWire;


    float startPosy;

    private bool yAxis = true;
    private bool xAxis = false;
   

    // Start is called before the first frame update
    void Start()
    {
        yellowCable = GameObject.FindGameObjectWithTag("Yellow");
        pinkCable = GameObject.FindGameObjectWithTag("Pink");
        blueCable = GameObject.FindGameObjectWithTag("Blue");
        player = FindInActiveObjectByName("Player");
        playerController = player.GetComponent<PlayerController>();
     

        pinkWire = pinkCable.GetComponent<PinkCable>();
        blueWire = blueCable.GetComponent<BlueCable>();
        yellowWire = yellowCable.GetComponent<YellowCable>();

    }



  
    // Update is called once per frame
    void Update()
    {
        if (yAxis)
        {
            transform.position = new Vector3(transform.position.x, yCenter + Mathf.PingPong(Time.time * 2, height) - height / 2f, -1);
        }
        else if (xAxis)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 2, height) - 4 / 2f, startPosy, -1);
        }
        

        if (Input.GetKeyDown(KeyCode.T) && !xAxis)
        {
            startPosy = transform.position.y;
            yAxis = false;
            xAxis = true;
 
        }
        else if (transform.position.x >= 4.67)
        {
            yAxis = true;
            xAxis = false;
            
        }

        if(pinkWire.pink && blueWire.blue && yellowWire.yellow)
        {
            Debug.Log("Load");
            SceneToLoad.ChangeLevelToLoad(level);
            playerController.ShowPlayerOnLoad();
            playerController.electricalCompleted = true;
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
