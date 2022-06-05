using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public GameObject InputName;
    //public GameObject BtnSaveAndQuit;
    //public GameObject BtnQuit;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SaveAndQuit()
    {
        SaveOption();
        if (GameManager.Instance.gameLaunched)
        {
            LoadGame();
        }
        else
        {
            LoadMainMenu();
        }
    }

    public void Quit()
    {
        LoadMainMenu();
    }
    public void UpdatePlayerName(string playerName)
    {

        GameManager.Instance.playerName = playerName;
    }

    public void SaveOption()
    {
        string playerName = InputName.GetComponent<TMP_InputField>().text;
        if (playerName != "")
        {
            UpdatePlayerName(playerName);
            GameManager.Instance.SaveOption();
        }
        else
        {
            Debug.Log("Enter valid name");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
