using UnityEngine;

public class AudioManager : MonoBehaviour, IAudioManager
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool _sfxIsMute;
    [SerializeField] private AudioClip _clickAudioClip;

    public void PlayButtonClick()
    {
        if (_sfxIsMute) return;
        Play(_clickAudioClip);
    }

    private void Play(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}