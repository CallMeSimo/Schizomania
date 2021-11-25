using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToLoad : MonoBehaviour
{
    public static void ChangeLevelToLoad(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
