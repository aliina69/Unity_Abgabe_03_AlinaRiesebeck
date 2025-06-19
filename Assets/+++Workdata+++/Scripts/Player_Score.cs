using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour
{
    public float timeLeft = 120;
    public int playerScore = 0;
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
        Debug.Log(playerScore);
    }
}
