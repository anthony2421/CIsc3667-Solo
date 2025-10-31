using UnityEngine;

public class balloonMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 2f;
    public Vector2 direction = Vector2.right;
    private SpriteRenderer spriteRenderer;
    private float screenBound;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        float half = spriteRenderer.bounds.extents.x;
        screenBound = Camera.main.orthographicSize * Camera.main.aspect - half;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > screenBound)
        {
            direction.x *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        
    }
}
