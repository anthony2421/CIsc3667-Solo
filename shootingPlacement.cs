using UnityEngine;

public class ShootPointFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float offsetX = 1f;

    private playerMovement playerMove;

    void Start()
    {
        playerMove = playerTransform.GetComponent<playerMovement>();
        if (playerMove == null)
            Debug.LogWarning("playerMovement script not found on playerTransform");
    }

    void Update()
    {
        if (playerMove != null)
        {
            // If player faces right, offset is positive, else negative
            float direction = playerMove.spriteRender.flipX ? -1f : 1f;
            Vector3 newPos = playerTransform.position + new Vector3(offsetX * direction, 0, 0);
            transform.position = newPos;
        }
    }
}
