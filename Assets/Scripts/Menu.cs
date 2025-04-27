using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region Privates
    [SerializeField] private CinemachineCamera cameraPlayer;
    [SerializeField] private GameObject VisualMenu;
    private bool isMenuOpen = false;
    #endregion

    void Start()
    {
        VisualMenu.SetActive(isMenuOpen);
    }
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isMenuOpen = !isMenuOpen;
            VisualMenu.SetActive(isMenuOpen);
            Time.timeScale = isMenuOpen ? 0f : 1f;
        }
    }
}
