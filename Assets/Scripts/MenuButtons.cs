using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    [SerializeField]
    private GameObject _oldWindow;

    [SerializeField]
    private GameObject _oldPanel;

    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _losePanel;

    [SerializeField]
    private GameObject _mainMenu;

    public void Start() {
        switch(DataHolder.gameResult) {
            case -1:
                break;
            case 0:
                _mainMenu.SetActive(false);
                _winPanel.SetActive(false);
                _losePanel.SetActive(true);
                break;
            case 1:
                _mainMenu.SetActive(false);
                _winPanel.SetActive(true);
                _losePanel.SetActive(false);
                break;
        }
        DataHolder.gameResult = -1;
    }
    public void StartScene() {
        SceneManager.LoadScene("MainGame");
    }
    
    public void Options(GameObject window) {
        window.SetActive(true);
        _oldWindow.SetActive(false);
    }

    public void BackToMenu(GameObject window) {
        window.SetActive(true);
        _oldPanel.SetActive(false);
        _oldWindow.SetActive(false);
    }
    public void Quit() {
        Application.Quit();
    }
}
