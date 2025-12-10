using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float speed = 8f; 
    private Vector3 direction = Vector3.up; 
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.y) > 8f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
}
