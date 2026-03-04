using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InGameBGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip _bgmClip;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventHub.GameStartEvent += StartBGM;
        EventHub.GameEndEvent += StopBGM;
        EventHub.GamePauseEvent += StopBGM;
        EventHub.GameResumedEvent += StartBGM;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= StartBGM;
        EventHub.GameEndEvent -= StopBGM;
        EventHub.GamePauseEvent -= StopBGM;
        EventHub.GameResumedEvent -= StartBGM;
    }

    private void StartBGM()
    {
        _audioSource.loop = true;

        if (_bgmClip != null)
        {
            _audioSource.clip = _bgmClip;
            _audioSource.Play();
        }
    }

    private void StopBGM()
    {
        _audioSource.Stop();
    }
}
