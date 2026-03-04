using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    public GameState CurrentGameState => _gameState;
    public void StartGame()
    {
        Debug.Log("Game Start");
      
        _gameState = GameState.Play;
        EventHub.GameStartAct();
    }
    public void EndGame()
    {
        Debug.Log("Game End");

        EventHub.GameEndEventAct();
        SceneTransitionManager.TransitionToResult();
    }

    private GameState _gameState = GameState.Countdown;

    private void Awake()
    {
        ServiceLocator.Register<InGameSceneManager, InGameSceneManager>();
    }

    private void Start()
    {
        StartGame();
    }


    private void OnTimeUp()
    {
        // TODO ：タイマーとの繋ぎこみをおこなう
        _gameState = GameState.End;
    }

    private void OnAllKill()
    {
        // TODO ：エネミーの再生成とのつなぎこみをおこなう
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
