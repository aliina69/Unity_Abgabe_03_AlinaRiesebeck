using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerSide : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpforce = 8;
    private float direction = 0f;
    // 

    private Rigidbody2D rb;

    [Header("GroundCheck")]
    [SerializeField] private Transform transformGroundCheck;
    //zugewiesenes Groundchecker object wird zwischen gespeichert, um dann die position später im script anwenden zu können 

    //in einer Layermask können wir ebenen aus unserem project zuweisen für die spätere verwendung im script
    [SerializeField] private LayerMask layerGround;
    
    
    [Header("Manager")] 
    [SerializeField] private CollectableManager collectableManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Player_Score playerScore;

    [SerializeField] private TextMeshProUGUI countDown;
    
    
    private bool canMove = true;

    void Start()
    {
        StartCoroutine(Countdown(3));
        rb = GetComponent<Rigidbody2D>();
    }
    //
    IEnumerator Countdown(int seconds)
    {
        canMove = false;
        int count = seconds;
        while (count > 0)
        {
            countDown.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        StartGame();
    }
   

    void StartGame()
    {
        canMove = true;
        StopCoroutine(Countdown(3));
        Destroy(countDown.gameObject);
    }
    
    void Update()
    {
        if (canMove)
        {
            direction = 0f;

            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }

            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }

            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }
    //movement for the character 


    void Jump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, radius: 0.1f, layerGround))
        {
            rb.linearVelocity = new Vector2(0, jumpforce);
        }
    }
    //


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with something!!");

        if (other.CompareTag("coin"))
        {
            Debug.Log("Collided with coin");
            Destroy(other.gameObject);
            collectableManager.AddCoin();
        }
        if (other.CompareTag("diamond"))
        {
            Debug.Log("Collided with diamond");
            Destroy(other.gameObject);
            collectableManager.AddDiamond();
        }
        else if (other.CompareTag("obstacle"))
        {
            Debug.Log("Collided with obstacle");
            uiManager.ShowPanelLose();
            rb.linearVelocity = Vector2.zero;
            canMove = false;
        }
        if (other.CompareTag("win"))
        {
            Debug.Log("Collided with win");
            Destroy(other.gameObject);
            uiManager.ShowPanelWin();
            canMove = false;
            uiManager.ShowPanelWin();
            //playerScore.CountScore();
        }
    }   
    
}
