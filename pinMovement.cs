using UnityEngine;

public class pinMovement : MonoBehaviour
{
    public float speed = 5f;
     private Vector3 moveDir = Vector3.up;


    public void SetDirection(Vector2 dir) {
        moveDir = dir.normalized;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);

        // Check if the pin has moved too far up or down on the screen.
        // If it goes beyond ±10 on the Y-axis, destroy it to clean up the scene.
        if (Mathf.Abs(transform.position.y) > 10f)
        {
            Destroy(gameObject);
        }
    }
}
