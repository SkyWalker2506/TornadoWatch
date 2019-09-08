using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    public GameObject WinScreen;
    [SerializeField]
    public GameObject LoseScreen;

    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);

    }

    public void ShowWinScreen()
    {
        WinScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        LoseScreen.SetActive(true);
    }

    public void RestartTheLevel()
    {
        LevelManager.Instance.RestartTheLevel();
    }

    public void GoToNextLevel()
    {
        LevelManager.Instance.GoToTheNextLevel();
    }
}
