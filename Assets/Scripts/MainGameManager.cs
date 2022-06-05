using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = GameManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
