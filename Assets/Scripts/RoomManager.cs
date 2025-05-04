using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*Cada vez que el personaje entre o salga de un cuarto, la pantalla debe hacer el efecto de
Fade In y Fade Out. Puede hacer un Singleton de Controlador de Escenas.*/

public class RoomManager : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1f;
    private bool isVisible;
    public Image fadePanel;
    public static RoomManager Instance { get; private set; }//Singleton

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        fadePanel.gameObject.SetActive(true);
        Instance.FadeIn();//Se hace el efecto
    }
    private void Update()
    {
        
    }
    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0)); // de negro a transparente
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1)); // de transparente a negro
    }

    IEnumerator Fade(float start, float end)
    {
        float time = 0f;
        Color color = fadePanel.color;
        color.a = start;
        fadePanel.color = color;

        while (time < 1f)
        {
            time += Time.deltaTime * fadeSpeed;
            float alpha = Mathf.Lerp(start, end, time);
            color.a = alpha;
            fadePanel.color = color;
            yield return null;
        }
        color.a = end;
        fadePanel.color = color;
        isVisible = false;
        fadePanel.gameObject.SetActive(isVisible);
    }
}
