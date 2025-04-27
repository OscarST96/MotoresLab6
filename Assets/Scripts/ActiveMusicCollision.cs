using UnityEngine;

public class ActiveMusicCollision : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource Enter;
    [SerializeField] private AudioSource Exit;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            if (!Music.isPlaying)
            {
                Music.Play();
                Enter.Play();
            }
            else if (Music.isPlaying)
            {
                Music.Stop();
                Exit.Play();
            }
        }
    }
    
}
