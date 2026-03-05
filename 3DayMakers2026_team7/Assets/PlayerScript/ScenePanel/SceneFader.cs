using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;

    [Header("Defalut Settings")]
    [SerializeField] private Image defaultFadeImage;
    [SerializeField] private float defaultFadeDuration = 1f;


    [SerializeField] private bool playFadeInOnStart = true; // © ƒeƒXƒg—p

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ===== –¾“] =====
    public static void FadeOut(
         float duration = -1f,
         Image targetImage = null)
    {
        if (Instance == null) return;

        float useDuration = duration > 0 ? duration : Instance.defaultFadeDuration;
        Image useImage = targetImage != null ? targetImage : Instance.defaultFadeImage;

        Instance.StartCoroutine(Instance.FadeRoutine(useImage, 0f, 1f, useDuration));
    }
    // ===== ˆÃ“]‚µ‚ÄƒV[ƒ“‘JˆÚ =====
    public static void FadeIn(
         float duration = -1f,
         Image targetImage = null)
    {
        if (Instance == null) return;

        float useDuration = duration > 0 ? duration : Instance.defaultFadeDuration;
        Image useImage = targetImage != null ? targetImage : Instance.defaultFadeImage;

        Instance.StartCoroutine(Instance.FadeRoutine(useImage, 1f, 0f, useDuration));
    }
    private IEnumerator FadeRoutine(Image img, float startAlpha, float endAlpha, float duration)
    {
        float time = 0f;

        Color color = img.color;
        color.a = startAlpha;
        img.color = color;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t);

            color.a = alpha;
            img.color = color;

            yield return null;
        }

        color.a = endAlpha;
        img.color = color;
    }

}
