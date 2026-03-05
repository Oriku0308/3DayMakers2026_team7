using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button _inGameStartButton;
    [SerializeField]
    private float _fadeDuration = 1f;


    void Start()
    {
        _inGameStartButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        //SceneTransitionManager.TransitionToInGame();
    }
}
