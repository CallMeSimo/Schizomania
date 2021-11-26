using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.parent = player.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Change as desired, try finding a more efficent way of handeling this.
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
