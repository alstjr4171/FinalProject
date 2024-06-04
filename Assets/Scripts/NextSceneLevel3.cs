using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == ("Player"))
        {
            LoadNextLevel();
        }
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene("Ending");
    }
}
