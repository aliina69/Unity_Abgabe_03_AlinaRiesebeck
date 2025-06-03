using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerSide : MonoBehaviour
{

    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpforce = 8;
    private float direction = 0f;

    private Rigidbody2D rb;

    [Header("GroundCheck")]
    //hier speichern wir das Transform des GrounCheck objects zwischen (muss natürlich vorher im inspektor zugewiesen werden)
    //damit wir die Position später im script verwenden können
    [SerializeField]
    private Transform transformGroundCheck;

    //in einer Layermask können wir ebenen aus unserem project zuweisen für die spätere verwendung im script
    [SerializeField] private LayerMask layerGround;

    /*[Header("Manager")] 
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private UIManager uiManager;*/

    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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


    void Jump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, radius: 0.1f, layerGround))
        {
            rb.linearVelocity = new Vector2(0, jumpforce);
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with something!!");

        if (other.CompareTag("coin"))
        {
            Debug.Log("Collided with coin");
            Destroy(other.gameObject);
            coinManager.AddCoin();
        }
        else if (other.CompareTag("obstacle"))
        {
            Debug.Log("Collided with obstacle");
            uiManager.ShowPanelLose();
            rb.linearVelocity = Vector2.zero;
            canMove = false;
        }
    }*/
}
