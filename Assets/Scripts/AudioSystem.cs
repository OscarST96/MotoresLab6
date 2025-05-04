using UnityEngine;
using UnityEngine.Audio;

/*Debe haber un menú de configuración donde el usuario pueda ajustar el Audio utilizando 3
canales: Master, Music y SFX. Debe usar AudioMixer y su configuración de grupos. Este
menú debe ser un Singleton y mantenerse entre las escenas.*/
public class AudioSystem : MonoBehaviour
{
    #region Privates
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSettingsData audioSettingsData;
    public static AudioSystem Instance;
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

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
