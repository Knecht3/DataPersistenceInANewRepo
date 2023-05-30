using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI enterNameInputText;
    public TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    // Display best score at start in the menu scene
    void Start()
    {
        bestScoreText.text = StartMenuManager.instance.DisplayBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        GetUserName();
    }

    // Press Start button to start the game
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    // Press Quit button to exit the game
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // Get user name from user's input
    void GetUserName()
    {
        StartMenuManager.instance.userName = enterNameInputText.text;
    }
}
