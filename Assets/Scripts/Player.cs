using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField]private Rigidbody rb;
    public float speed = 5;

    [SerializeField]private AudioSource audioSFX;
    [SerializeField]private AudioSource ChangeScene;
    private float minVelocity = 0.001f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude > minVelocity)
        {
            if (!audioSFX.isPlaying)
            {
                audioSFX.Play();
            }
        }
        else
        {
            if (audioSFX.isPlaying)
            {
                audioSFX.Stop();
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 mov = new Vector3(direction.x, 0, direction.y);
        rb.linearVelocity = mov * speed;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scene"))
        {
            SceneManager.LoadScene(1);
            ChangeScene.Play();
        }
    }
}
