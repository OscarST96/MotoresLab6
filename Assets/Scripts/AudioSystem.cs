using UnityEngine;
using UnityEngine.Audio;


public class AudioSystem : MonoBehaviour
{
    #region Privates
    [SerializeField] private AudioMixer audioMixer;
    #endregion

    #region VoidVolume
    public void Volumen(float sliderValue)
    {
        audioMixer.SetFloat("Sonido", Mathf.Log10(sliderValue) * 20);
    }
    public void VolumenMusic(float sliderValue)
    {
        audioMixer.SetFloat("SonidoMusic", Mathf.Log10(sliderValue) * 20);
    }
    public void VolumenSFX(float sliderValue)
    {
        audioMixer.SetFloat("SonidoSFX", Mathf.Log10(sliderValue) * 20);
    }
    #endregion
}
