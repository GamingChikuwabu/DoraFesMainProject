using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreen : MonoBehaviour
{
    public Image logo;
    public Image blackBackground;
    public TitleLogoAnimation titleLogoAnimation;
    public float fadeDuration = 1f;
    public float logoDisplayDuration = 2f;

    void Start()
    {
        // Start sequence
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
       // Make sure logo is transparent at start
    logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, 0f);

    // Make sure blackBackground is opaque at start
    blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, 1f);

    // Fade in logo
    yield return logo.DOFade(1f, fadeDuration).WaitForCompletion();

    // Wait for a while
    yield return new WaitForSeconds(logoDisplayDuration);

    // Fade out logo
    yield return logo.DOFade(0f, fadeDuration).WaitForCompletion();

    // Fade out black background
    yield return blackBackground.DOFade(0f, fadeDuration).WaitForCompletion();

    // Now start the title logo animation
    titleLogoAnimation.AnimateTitleLogo();

    //オブジェクト削除
    gameObject.SetActive(false);

    }
}
