using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TransitionFade : MonoBehaviour
{
    private CanvasGroup transitionCard;
    private float fadeTime = 1f;
    [SerializeField] private TMP_Text text;

    public void Start()
    {
        transitionCard = GetComponent<CanvasGroup>();
        StartCoroutine(DisplayCard());
        FadeOut();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(transitionCard, 0, 1f, fadeTime));
    }

    public void FadeOut()
    {

        StartCoroutine(FadeCanvasGroup(transitionCard, 1f, 0, fadeTime));
    }

    public void UpdateText(string txt)
    {
        text.text = txt;
    }

    IEnumerator DisplayCard()
    {
        transitionCard.alpha = 1;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime)
    {
        float time = 0;
        
        while (time < lerpTime)
        {
            float currentAlpha = Mathf.Lerp(start, end, time / lerpTime);
            cg.alpha = currentAlpha;
            time += Time.deltaTime;
            yield return null;
        }

        cg.alpha = end;
    }
}
