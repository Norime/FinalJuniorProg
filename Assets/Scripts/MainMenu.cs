using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public GameObject BtnStart;
    public GameObject BtnOption;
    public GameObject BtnExit;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadOption();
        GameManager.Instance.gameLaunched = false;
        playerNameText.text = GameManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        GameManager.Instance.gameLaunched = true;
        SceneManager.LoadScene(1);
        //string playerName = InputName.GetComponent<TMP_InputField>().text;
        //if (playerName != "")
        //{
        //    UpdatePlayerName(playerName);
        //    SceneManager.LoadScene(1);
        //}
        //else
        //{
        //    Debug.Log("Enter valid name");
        //}
    }

    public void LoadOption()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
