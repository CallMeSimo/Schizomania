using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longvisare : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {
        VisareOchSpelarePosition();
    }

    //Rrotates long clock hand
    void VisareOchSpelarePosition()
    {
        transform.rotation = Quaternion.Euler(0,0, player.transform.position.x * -10 + 90);
    }

}