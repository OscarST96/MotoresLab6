using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/*Cuando el jugador presione el botón de Interactuar (New Input System) debe aparecer un
cuadro mensaje o imagen en el Canvas, mostrando que se interactúo con el NPC. Este
mensaje debe desaparecer luego de un rato; asimismo, el NPC, recién continuará con su
movimiento.*/
public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private AudioSource audioSFX;
    [SerializeField] private AudioSource ChangeScene;
    [SerializeField] private NPCs NPCs;
    [SerializeField]private SystemText systemText;
    private Rigidbody rb;
    public float speed = 5;
    private float minVelocity = 0.001f;
    private bool onMovementPlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        onMovementPlayer = true;
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
        if (onMovementPlayer)
        {
            Vector3 mov = new Vector3(direction.x, 0, direction.y);
            rb.linearVelocity = mov * speed;
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && NPCs.OnDialogue)
        {
            onMovementPlayer = false;
            NPCs.DialogPanel.SetActive(true);
            NPCs.PauseMovement(systemText.TimeActive);
            systemText.ExitPanel();
            StartCoroutine(ResumeAfterDelay());
        }
    }
    IEnumerator ResumeAfterDelay()
    {
        yield return new WaitForSeconds(systemText.TimeActive);

        NPCs.DialogPanel.SetActive(false);
        onMovementPlayer = true;
    }


}
