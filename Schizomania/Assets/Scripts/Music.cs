using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource bombBeats;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        bombBeats.Play();
    }
}
