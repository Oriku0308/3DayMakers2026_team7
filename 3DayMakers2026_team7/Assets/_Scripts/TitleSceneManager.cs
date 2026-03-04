using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button _inGameStartButton;
    

    void Start()
    {
        _inGameStartButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneTransitionManager.TransitionToInGame();
    }
}
