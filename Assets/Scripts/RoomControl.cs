using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RoomControl : MonoBehaviour
{
    [SerializeField] private RoomAudioData audioData;
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource Enter;
    [SerializeField] private AudioSource Exit;

    private void Awake()
    {
        Music = gameObject.AddComponent<AudioSource>();
        Enter = gameObject.AddComponent<AudioSource>();
        Exit = gameObject.AddComponent<AudioSource>();

        Music.clip = audioData.musicClip;
        Music.outputAudioMixerGroup = audioData.musicMixer;

        Enter.clip = audioData.enterSFX;
        Enter.outputAudioMixerGroup = audioData.sfxMixer;

        Exit.clip = audioData.exitSFX;
        Exit.outputAudioMixerGroup = audioData.sfxMixer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            FadePanel();
            Enter.Play();
            Music.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FadePanel();
            Exit.Play();
            Music.Stop();
        }
    }
    private void FadePanel()
    {
        RoomManager.Instance.fadePanel.gameObject.SetActive(true);
        RoomManager.Instance.FadeOut();
        RoomManager.Instance.FadeIn();
    }
}
