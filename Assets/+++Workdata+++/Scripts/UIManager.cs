using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCounterCoin;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelWin;
    [SerializeField] Button buttonRestart;
    [SerializeField] Button buttonMainMenu;

    private void Start()
    {
        panelLose.SetActive(false);
        panelWin.SetActive(false);
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonMainMenu.onClick.AddListener(GoToMainMenu);
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
}
