using System.Collections;
using UnityEngine;

/*Dentro del cuarto debe haber un personaje (NPC) que se podría utilizar en futuros proyectos.
Se desea poder poner NPCs que se muevan alrededor de puntos del cuarto, pero que se
queden quietos un tiempo cuando lleguen a un punto (use coroutines).*/
public class NPCs : MonoBehaviour
{
    [SerializeField] private Transform transformNpc;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Vector2 direction = new Vector2(0, 0);
    [SerializeField] private SystemText systemText;
    private bool onMovement;
    private bool onDialogue = false;
    public float speed;

    public bool OnDialogue => onDialogue;
    public GameObject DialogPanel => dialogPanel;

    void Start()
    {
        transformNpc = GetComponent<Transform>();
        dialogPanel.SetActive(false);
    }
    void Update()
    {
        if (!onMovement)
        {
            Movement();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cuarto"))
        {
            StartCoroutine(WaitOnPoint());
        }
        if (other.CompareTag("Player"))
        {
            onDialogue = true;
            StartCoroutine(WaitOnPoint());
        }
    }
    private void Movement()
    {
        transformNpc.position = new Vector3(transformNpc.position.x + speed * direction.x * Time.deltaTime, transformNpc.position.y, transformNpc.position.z + speed * direction.y * Time.deltaTime);

        if (transformNpc.position.x <= -18f && direction.x == -1)
        {
            direction.x = 0;
            direction.y = 1;
        }
        if (transformNpc.position.x >= 18f && direction.x == 1)
        {
            direction.x = 0;
            direction.y = -1;
        }
        if (transformNpc.position.z >= 15f && direction.y == 1)
        {
            direction.y = 0;
            direction.x = 1;
        }
        if (transformNpc.position.z <= 5f && direction.y == -1)
        {
            direction.y = 0;
            direction.x = -1;
        }
    }
    IEnumerator WaitOnPoint()//coroutines
    {
        onMovement = true;
        yield return new WaitForSeconds(systemText.TimeActive);
        onMovement = false;
    }
    public void PauseMovement(float seconds)
    {
        StartCoroutine(PauseCoroutine(seconds));
    }

    private IEnumerator PauseCoroutine(float seconds)
    {
        onMovement = true;
        yield return new WaitForSeconds(seconds);
        onMovement = false;
    }

}
