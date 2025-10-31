using UnityEngine;

public class popAudio : MonoBehaviour
{
    public AudioClip popSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            if (audioSource != null && popSound != null)
            {
                audioSource.PlayOneShot(popSound);
            }
            balloonGrowth balloon = other.GetComponent<balloonGrowth>();
            if (balloon != null)
            {
                balloon.Pop();
            }
            Destroy(gameObject, 0.05f);
        }
    }
}

