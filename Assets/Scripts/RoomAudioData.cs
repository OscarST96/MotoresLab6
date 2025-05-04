using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "RoomAudioData", menuName = "Audio/Room Audio Data")]
public class RoomAudioData : ScriptableObject
{
    public AudioClip musicClip;
    public AudioClip enterSFX;
    public AudioClip exitSFX;
    public AudioMixerGroup musicMixer;
    public AudioMixerGroup sfxMixer;
}
