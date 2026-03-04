using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル、インゲーム、リザルトへの遷移を管理するクラス
/// </summary>
public static class SceneTransitionManager
{
    private readonly static string titleSceneName = "TitleScene";
    private readonly static string inGameSceneName = "InGameScene";
    private readonly static string resultSceneName = "ResultScene";

    /// <summary>
    /// タイトルへ遷移
    /// </summary>
    public static void TransitionToTitle()
    {
        /// シーンが存在するか確認する、指定されたシーン名がBuildSettingに存在しない場合falseを返す
        if (Application.CanStreamedLevelBeLoaded(titleSceneName))
        {
            SceneManager.LoadScene(titleSceneName);
        }
        else
        {
            Debug.LogError($"シーンが見つかりません：'{titleSceneName}'\nタイポミスがないか、BuildSettingsに登録されているかを確認してください");
        }
    }

    /// <summary>
    /// インゲームへ遷移
    /// </summary>
    public static void TransitionToInGame()
    {
        if (Application.CanStreamedLevelBeLoaded(inGameSceneName))
        {
            SceneManager.LoadScene(inGameSceneName);
        }
        else
        {
            Debug.LogError($"シーンが見つかりません：'{inGameSceneName}'\nタイポミスがないか、BuildSettingsに登録されているかを確認してください");
        }
    }

    /// <summary>
    /// リザルトへ遷移
    /// </summary>
    public static void TransitionToResult()
    {
        if (Application.CanStreamedLevelBeLoaded(resultSceneName))
        {
            SceneManager.LoadScene(resultSceneName);
        }
        else
        {
            Debug.LogError($"シーンが見つかりません：'{resultSceneName}'\nタイポミスがないか、BuildSettingsに登録されているかを確認してください");
        }
    }

    /// <summary>
    /// 指定されたシーンへ遷移
    /// </summary>
    /// <param name="sceneName">遷移先シーン名</param>
    public static void TransitionToAnyScene(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"シーンが見つかりません：'{sceneName}'\nタイポミスがないか、BuildSettingsに登録されているかを確認してください");
        }
    }
}