using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private Button _returnToTitleButton;

    void Start()
    {
        _returnToTitleButton.onClick.AddListener(OnTitleButtonClick);
    }

    private void OnTitleButtonClick()
    {
        SceneTransitionManager.TransitionToTitle();
    }
}
