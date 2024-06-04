using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTitle : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
