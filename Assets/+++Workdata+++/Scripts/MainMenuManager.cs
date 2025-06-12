#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonEnd;

    void Start()
    {
        mainMenu.SetActive(true);
        buttonPlay.onClick.AddListener(StartGame);
        buttonEnd.onClick.AddListener(EndGame);
    }
    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void EndGame()
    {
        if (Application.isPlaying)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}