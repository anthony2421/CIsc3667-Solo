using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject pin;
    public Transform shootPoint;
    public playerMovement playerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootPin();
        }
        void shootPin()
        {
            GameObject pinInstance = Instantiate(pin, shootPoint.position, Quaternion.identity);
            pinMovement pinMove = pinInstance.GetComponent<pinMovement>();
            if (pinMove != null)
            {
                Vector2 dir = playerMove.spriteRender.flipX ? Vector2.left : Vector2.right;
                pinMove.SetDirection(dir);
                pinMove.enabled = true;
            }
        }
    }
}
