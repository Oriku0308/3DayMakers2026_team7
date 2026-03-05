using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameSceneManager : MonoBehaviour
{
    private GameState _gameState = GameState.Countdown;
    public GameState CurrentGameState => _gameState;

    private const int CountdownTime = 3; // カウントダウンの時間（秒）
    private const int EndWaitTime = 3; // ゲーム後の待ち時間（秒）

    [SerializeField]
    private TextMeshProUGUI _infoText; // 画面真ん中に大きく表示するテキスト（例: 最初のカウントダウン、終了時など）


    private void Awake()
    {
        ServiceLocator.Register<InGameSceneManager, InGameSceneManager>();
    }
    private void OnEnable()
    {
        EventHub.OnAllKidGoodEvent += OnAllKill;
        EventHub.GameEndEvent += EndGame;
    }

    private void OnDisable()
    {
        EventHub.OnAllKidGoodEvent -= OnAllKill;
        EventHub.GameEndEvent -= EndGame;
    }

    private void Start()
    {
        StartCoroutine(StartPerformance());
    }

    private IEnumerator StartPerformance()
    {
        _gameState = GameState.Countdown;
        // カウントダウン
        for (int i = CountdownTime; i > 0; i--)
        {
            Debug.Log(i);
            // TODO: 音素材の再生など
            _infoText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        // TODO: スタートの音素材の再生など
        _infoText.text = "開始";
        yield return new WaitForSeconds(1f);
        _infoText.text = "";

        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Game Start");

        _gameState = GameState.Play;
        EventHub.GameStartAct();
    }



    private IEnumerator EndPerformance()
    {
        // TODO: ゲーム終了時のブザー音、UI表示など

        // ブザー音の間待たせたい
        for (int i = EndWaitTime; i > 0; i--)
        {
            Debug.Log(i);
            _infoText.text = "終了";
            yield return new WaitForSeconds(1f);
        }
        SceneTransitionManager.TransitionToResult();
    }
    public void EndGame()
    {
        Debug.Log("Game End");
        _gameState = GameState.End;
        StartCoroutine(EndPerformance());
    }


    private void OnAllKill()
    {
        // TODO: 全員倒したときの処理、何か決定したら足す
        Debug.Log("All Kids are Good!");
    }


    private void OnDestroy()
    {
        ServiceLocator.Remove<InGameSceneManager>();
    }
}

/// ゲームの状態を管理する列挙型、一応用意したがいらなければ消す
public enum GameState
{
    Countdown,
    Pose,
    Play,
    End
}
