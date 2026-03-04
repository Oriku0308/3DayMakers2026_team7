using System.Threading.Tasks;
using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    public GameState CurrentGameState => _gameState;
    public async Task StartGame()
    {
        Debug.Log("5秒待つ");
        await Task.Delay(5000);

        Debug.Log("Game Start");
      
        _gameState = GameState.Play;
        EventHub.GameStartAct();
    }
    public void EndGame()
    {
        Debug.Log("Game End");

        SceneTransitionManager.TransitionToResult();
    }

    private GameState _gameState = GameState.Countdown;

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
        StartGame();
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
