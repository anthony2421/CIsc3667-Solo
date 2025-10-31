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

    /*Taken from PlayerMovement.cs from brightspace
    void FixedUpdate() 
    {
        // Calculate new position based on input and speed
        Vector2 newPos = rb.position + moveInput * speed * Time.fixedDeltaTime;

        // Get camera boundaries to prevent player from leaving the screen
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
    */
}
