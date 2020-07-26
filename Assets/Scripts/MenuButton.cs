using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    private Button menuButton;
    private GameManager gameManagerScript;

    void Start()
    {
        menuButton = GetComponent<Button>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        menuButton.onClick.AddListener(SetDifficulty);
    }


    void Update()
    {
        
    }

    void SetDifficulty() {
        if (menuButton.name == "Normal Button") {
            gameManagerScript.StartGame(1);
		}

        if (menuButton.name == "Hard Button") {
            gameManagerScript.StartGame(2);
		}

        if (menuButton.name == "How To Play Button") {
            gameManagerScript.StartTutorial();
		}
	}
}
