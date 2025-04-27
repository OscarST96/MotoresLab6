using UnityEngine;
using UnityEngine.Audio;


public class AudioSystem : MonoBehaviour
{
    #region Privates
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSettingsData audioSettingsData;
    #endregion
    private void Start()
    {
        //al empezar se aplica los valores guardados
        Volumen(audioSettingsData.masterVolume);
        VolumenMusic(audioSettingsData.musicVolume);
        VolumenSFX(audioSettingsData.sfxVolume);
    }

    #region VoidVolume
    public void Volumen(float sliderValue)
    {
        audioMixer.SetFloat("Sonido", Mathf.Log10(sliderValue) * 20);
        audioSettingsData.masterVolume = sliderValue;

    }
    public void VolumenMusic(float sliderValue)
    {
        audioMixer.SetFloat("SonidoMusic", Mathf.Log10(sliderValue) * 20);
        audioSettingsData.musicVolume = sliderValue;
    }
    public void VolumenSFX(float sliderValue)
    {
        audioMixer.SetFloat("SonidoSFX", Mathf.Log10(sliderValue) * 20);
        audioSettingsData.sfxVolume = sliderValue;
    }
    #endregion
}
