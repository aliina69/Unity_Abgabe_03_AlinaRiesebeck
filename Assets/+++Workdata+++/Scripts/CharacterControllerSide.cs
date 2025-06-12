using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

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
    //
    
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //

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
        else if (other.CompareTag("obstacle"))
        {
            Debug.Log("Collided with obstacle");
            uiManager.ShowPanelLose();
            rb.linearVelocity = Vector2.zero;
            canMove = false;
        }
    }
    //
}
