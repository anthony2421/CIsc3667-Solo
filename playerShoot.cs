using UnityEngine;
using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
    public GameObject pinPrefab;
    public float pinSpeed = 8f;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        
        if (Input.GetButtonDown("Fire1")) // allows for ctrl & left click to shoot.
        {
            ShootPin();
        }
    }

    void ShootPin()
    {
        GameObject pin = Instantiate(pinPrefab, transform.position, Quaternion.identity);

        var move = pin.GetComponent<ballMovement>();
        if (move != null)
        {
            move.SetDirection(Vector3.up);
            move.speed = pinSpeed;
        }
    }
}
