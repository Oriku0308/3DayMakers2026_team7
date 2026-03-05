using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private Button _returnToTitleButton;
    [SerializeField] private float _fadeDuration = 1f;

    void Start()
    {
        SceneFader.FadeIn(_fadeDuration);
        _returnToTitleButton.onClick.AddListener(OnTitleButtonClick);
    }

    private void OnTitleButtonClick()
    {
        // SceneTransitionManager.TransitionToTitle();
    }
}
