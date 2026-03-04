using UnityEngine;
using TMPro;

/// <summary>
/// InGame中のTimerを管理するクラス
/// </summary>

public class TimeManager : MonoBehaviour
{
    public float CurrentTime { get; private set; }

    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private float _maxTime = 90f;

    private bool _isTimerRunning = false;

    // 以下はpublicメゾット
    public void TimerReset()
    {
        CurrentTime = _maxTime;
        _isTimerRunning = false;
        UpdateText();
    }

    // 以下はprivateメゾット

    private void Start()
    {
        TimerReset();
    }

    private void Update()
    {
        if (!_isTimerRunning) return;

        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            UpdateText();

            if(CurrentTime <= 0)
            {
                CurrentTime = 0;
                UpdateText();
                OnTimeUp();
                return;
            }
        }
    }

    private void OnEnable()
    {
        EventHub.GameStartEvent += StartTimer;
        EventHub.GameEndEvent += StopTimer;
        EventHub.GamePauseEvent += StopTimer;
        EventHub.GameResumedEvent += StartTimer;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= StartTimer;
        EventHub.GameEndEvent -= StopTimer;
        EventHub.GamePauseEvent -= StopTimer;
        EventHub.GameResumedEvent -= StartTimer;
    }

    [ContextMenu("StartTimer")]
    private void StartTimer()
    {
        _isTimerRunning = true;
    }

    [ContextMenu("StopTimer")]
    private void StopTimer()
    {
        _isTimerRunning = false;
    }

    private void UpdateText()
    {
        // TimerのText表示を更新
        if (_timeText != null)
        {
            _timeText.text = Mathf.CeilToInt(CurrentTime).ToString();
        }
    }

    private void OnTimeUp()
    {
        // タイムアップ時の処理をここに記述
        StopTimer();;
        Debug.Log("Time's up!");

        EventHub.GameEndEventAct();
    }
}
