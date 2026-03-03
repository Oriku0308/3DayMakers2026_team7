using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register<GameFlowManager, GameFlowManager>();
    }

    public void StartGame()
    {
        EventHub.GameStartAct();
    }

    private void OnTimeUp()
    {

    }

    /// <summary>
    /// TODO ：エネミーの再生成とのつなぎこみをおこなう
    /// </summary>
    private void OnAllKill()
    {

    }

    public void EndGame()
    {
        EventHub.GameEndEventAct();
    }

    private void OnDestroy()
    {
        ServiceLocator.Remove<GameFlowManager>();
    }
}
