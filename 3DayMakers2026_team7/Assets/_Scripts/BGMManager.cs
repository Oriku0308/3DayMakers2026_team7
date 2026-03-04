using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip _bgmClip;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;

        if(_bgmClip != null)
        {
            _audioSource.clip = _bgmClip;
            _audioSource.Play();
        }
    }
}
