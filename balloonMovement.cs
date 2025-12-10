using UnityEngine;

public class balloonMovement : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 direction = Vector3.right; //Starts moving right
    private SpriteRenderer sr;
    private float screenLeft, screenRight;
    private float halfWidth;

    //Taken from professor & modified
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        halfWidth = sr.bounds.extents.x;

        // Taken from professor
        Camera cam = Camera.main;
        if (cam == null) return; // Safety check
        float camDistance = Mathf.Abs(cam.transform.position.z - transform.position.z);
        Vector3 rightEdge = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, camDistance));
        Vector3 leftEdge = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, camDistance));
        screenRight = rightEdge.x;
        screenLeft = leftEdge.x;
    }

    void Update()
    {
        // Move the balloon in the current direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the balloon has reached the right edge of the screen
        if (transform.position.x +halfWidth > screenRight)
        {
            direction = Vector3.left;
            if (sr != null) sr.flipX = true;
        }
        // Check if the balloon has reached the left edge of the screen
        else if (transform.position.x - halfWidth < screenLeft)
        {
            direction = Vector3.right;
            if (sr != null) sr.flipX = false;
        }
    }
}
