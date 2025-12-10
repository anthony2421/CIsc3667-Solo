using UnityEngine;
using UnityEngine.SceneManagement;

public class popContact : MonoBehaviour
{
    public AudioClip popSound;
    private AudioSource audioSource;
    private GameManager gameManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameManager.Instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            AudioSource.PlayClipAtPoint(popSound, transform.position, 1f);
            Destroy(other.gameObject, 0.05f);
            Destroy(gameObject, 0.05f);
            GameManager.Instance.AddScore(1);
        }
    }
}