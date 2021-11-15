using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    private PlayerController PlayerController;

    public enum PlayerState
    {
        Idle,
        walking,
        Dead,
        Falling
    }

    PlayerState myState;

    private void Start()
    {
        myState = PlayerState.Idle;

        PlayerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.groundDetection());
    }
}
