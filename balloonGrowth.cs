using UnityEngine;

public class balloonGrowth : MonoBehaviour
{

    public AudioClip popSound;
    private AudioSource audioSource;
        public void Pop()
    {
        if (audioSource != null && popSound != null)
        {
            audioSource.PlayOneShot(popSound);
        }
        Debug.Log("Balloon popped!");
        Destroy(gameObject);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
