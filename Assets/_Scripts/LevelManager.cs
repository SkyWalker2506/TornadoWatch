using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    public void RestartTheLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToTheNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(SceneManager.sceneCountInBuildSettings>nextLevel)
        SceneManager.LoadSceneAsync(nextLevel);
        else
        {
            print("There is no level left");
        }
    }


    public void OpenLevel(int index)
    {
            SceneManager.LoadSceneAsync(index);
    }
}
