using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SEManager : MonoBehaviour
{
    // SEの種類定義
    public enum SEType
    {
        GameStart,
        GameEnd,
        Pause,
        Resume,
        BadKidHit,
        GoodKidHit,
        AllKidGood,
        ScoreChanged,
        ButtonClick,
        BulletShot,
        WallReflect,
        Countdown,
        LastCount
    }

    //　SEの種類と対応するAudioClipを格納するためのクラス
    [System.Serializable]
    public class SEdata
    {
        public SEType Type;
        public AudioClip Clip;
    }

    // ボタンが押されたときのSE再生とシーン遷移を行うメソッド
    private void OnButtonClick()
    {
        StartCoroutine(OnButtonClickCoroutine());
    }

    private IEnumerator OnButtonClickCoroutine()
    {
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (currentSceneName == "TitleScene")
        {
            AudioClip clip = _seTable[SEType.AllKidGood];
            PlaySE(SEType.AllKidGood);       // ← 先に再生
            yield return new WaitForSeconds(clip.length);
            SceneTransitionManager.TransitionToInGame();
        }
        if (currentSceneName == "ResultScene")
        {
            AudioClip clip = _seTable[SEType.ButtonClick];
            PlaySE(SEType.ButtonClick);      // ← 先に再生
            yield return new WaitForSeconds(clip.length);
            SceneTransitionManager.TransitionToTitle();
        }

        Debug.Log("Button Clicked");
    }

    // SEを再生するためのメソッド
    public void PlaySE(SEType type)
    {
        if (_seTable.TryGetValue(type, out var clip))
        {
            _audioSource.PlayOneShot(clip);
        }
    }

    // SEの種類とClipをInspectorで設定するリスト
    [SerializeField] private List<SEdata> _seSettings;

    // SEの種類とClipを管理するDictionary
    private Dictionary<SEType, AudioClip> _seTable;
    private AudioSource _audioSource;

    // ボタンが不要なシーンには空のままでも稼働可能
    [SerializeField] private Button _button;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _seTable = new Dictionary<SEType, AudioClip>();

        // SEdataリストからDictionaryに変換して格納
        foreach (var seData in _seSettings)
        {
            // 同じSETypeが複数登録されないようにチェック
            if (!_seTable.ContainsKey(seData.Type))
            {
                // SETypeをキー、AudioClipを値としてDictionaryに追加
                _seTable.Add(seData.Type, seData.Clip);
            }
        }
    }

    private void Start()
    {
        PlaySE(SEType.GameStart);
        // ボタンがアタッチされている場合、クリックイベントにリスナーを追加
        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        //// シーンがInGameSceneの場合、ゲーム開始SEを再生し、カウントダウンを開始
        //if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "InGameScene")
        //{
        //    StartCoroutine(AutoCountDown());
        //}
    }

    private void CountDown()
    {

        PlaySE(SEType.Countdown);
    }

    private IEnumerator WaitToTransition(AudioClip clip)
    {
        // SEを再生してからシーン遷移するまで待機
        _audioSource.PlayOneShot(clip);

        // SEの長さだけ待機
        yield return new WaitForSeconds(clip.length);

        // 現在のシーンに応じて遷移先を決定
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (currentSceneName == "TitleScene")
        {
            SceneTransitionManager.TransitionToInGame();
        }
        else if (currentSceneName == "ResultScene")
        {
            SceneTransitionManager.TransitionToTitle();
        }
    }

    // イベントの購読と解除
    private void OnEnable()
    {
        EventHub.GameStartEvent += OnGameStart;
        EventHub.GameEndEvent += OnGameEnd;
        EventHub.GamePauseEvent += OnGamePause;
        EventHub.GameResumedEvent += OnGameResume;
        EventHub.BadKidHitEvent += OnBadKidHit;
        EventHub.GoodKidHitEvent += OnGoodKidHit;
        EventHub.ScoreChangedEvent += OnScoreChanged;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= OnGameStart;
        EventHub.GameEndEvent -= OnGameEnd;
        EventHub.GamePauseEvent -= OnGamePause;
        EventHub.GameResumedEvent -= OnGameResume;
        EventHub.BadKidHitEvent -= OnBadKidHit;
        EventHub.GoodKidHitEvent -= OnGoodKidHit;
        EventHub.ScoreChangedEvent -= OnScoreChanged;
    }

    private void OnGameStart() => PlaySE(SEType.GameStart);
    private void OnGameEnd() => PlaySE(SEType.GameEnd);
    private void OnGamePause() => PlaySE(SEType.Pause);
    private void OnGameResume() => PlaySE(SEType.Resume);
    private void OnBadKidHit() => PlaySE(SEType.BadKidHit);
    private void OnGoodKidHit() => PlaySE(SEType.GoodKidHit);
    private void OnScoreChanged(int score) => PlaySE(SEType.ScoreChanged);
}
