using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private Vector2 moveInput;
    private Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Vector2.zero;
        var keyboard = Keyboard.current;
        anim.SetBool("Running", false);
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            moveInput.x -= 1; 
            sr.flipX = true;
            anim.SetBool("Running", true);
        }
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            moveInput.x += 1;
            sr.flipX = false;
            anim.SetBool("Running", true);
        }
        moveInput = moveInput.normalized;
        Debug.Log(moveInput);
    }

    void FixedUpdate(){
        Vector2 newPos = rb.position + moveInput * speed * Time.fixedDeltaTime;

        //Taken from professor script
        Camera cam = Camera.main;
        if (cam != null)
        {
            float vertExtent = cam.orthographicSize;           // Half of vertical view size
            float horzExtent = vertExtent * cam.aspect;        // Half of horizontal view size

            // Define screen bounds
            float leftBound = -horzExtent;
            float rightBound = horzExtent;
            float bottomBound = -vertExtent;
            float topBound = vertExtent;

            // Clamp player position inside screen bounds
            newPos.x = Mathf.Clamp(newPos.x, leftBound, rightBound);
            newPos.y = Mathf.Clamp(newPos.y, bottomBound, topBound);
        }

        // Move the Rigidbody2D to the new position
        rb.MovePosition(newPos);
    }
}

/*
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public SpriteRenderer spriteRender;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(X, Y).normalized;
        rb.linearVelocity = move * moveSpeed;

        if (X > 0)
        {
            spriteRender.flipX = false;
        }
        else if (X < 0)
        {
            spriteRender.flipX = true;
        }
    }
}*/