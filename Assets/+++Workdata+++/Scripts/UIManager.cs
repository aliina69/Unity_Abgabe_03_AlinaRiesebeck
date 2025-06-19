using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("----PANELS----")]
    [SerializeField] private TMP_Text txtCounterCoin;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelWin;
    
    [Header("----BUTTONS----")]
    [SerializeField] Button buttonRestart;
    [SerializeField] Button buttonMainMenuReset;
    [SerializeField] Button buttonMainMenuWin;

    private void Start()
    {
        panelLose.SetActive(false);
        panelWin.SetActive(false);
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonMainMenuReset.onClick.AddListener(GoToMainMenu);
        buttonMainMenuWin.onClick.AddListener(GoToMainMenu);
    }


    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   

    public void UpdateCoinText(int newCoinCount)
    {
        txtCounterCoin.text = newCoinCount.ToString();
    }

    public void ShowPanelLose()
    {
        panelLose.SetActive(true);
    }
    public void ShowPanelWin()
    {
        panelWin.SetActive(true);
    }

}
