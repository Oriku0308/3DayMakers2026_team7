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
    public void Awake()
    {
        CurrentTime = _maxTime;
    }

    // 以下はprivateメゾット

    private void Update()
    {
        if (!_isTimerRunning) return;

        if(CurrentTime > 0)
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
        // EventManager.OnGameStarted += StartTimer;
        // EventManager.OnGameEnded += StopTimer;
        // EventManager.OnGamePaused += StopTimer;
        // EventManager.OnGameResumed += StartTimer;
    }

    private void OnDisable()
    {
        // EventManager.OnGameStarted -= StartTimer;
        // EventManager.OnGameEnded -= StopTimer;
        // EventManager.OnGamePaused -= StopTimer;
        // EventManager.OnGameResumed -= StartTimer;
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
        if(_timeText != null)
        {
            // TimerのText表示を更新
            if (_timeText != null)
            {
                _timeText.text = Mathf.CeilToInt(CurrentTime).ToString();
            }
        }
    }

    private void OnTimeUp()
    {
        // タイムアップ時の処理をここに記述
        StopTimer();
        Debug.Log("Time's up!");

        // EventManager.OnGameEnded?.Invork();
    }
}
