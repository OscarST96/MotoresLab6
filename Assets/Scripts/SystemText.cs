using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SystemText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTime;
    private float timeActive = 5f;
    private float timeInit = 1;
    private float currentTime;
    private bool isCounting = false;


    public float TimeActive => timeActive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        {
            currentTime += Time.deltaTime;

            float remainingTime = Mathf.Max(0, timeActive - currentTime);
            textTime.text = "Exit: " + remainingTime.ToString("F1");

            if (currentTime >= timeActive)
            {
                isCounting = false;
                textTime.text = ""; // Oculta el texto
                currentTime = 0f;
            }
        }
    }
    public void ExitPanel()
    {
        currentTime = 0f;
        isCounting = true;
    }
}
