using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class FeverManager : MonoBehaviour
{
    public Volume volume;
    public float feverTime = 1f;
    public float chromaticIntensityStart = 0f;
    public float chromaticIntensityEnd = 1f;
    public float lensDistortionIntensityStart = 0f;
    public float lensDistortionIntensityEnd = -1f;

    private ChromaticAberration chromaticAberration;
    private LensDistortion lensDistortion;
    private Tweener chromaticTweener;
    private Tweener lensDistortionTweener;

    private void Start()
    {
        // Get Chromatic Aberration
        volume.profile.TryGet(out chromaticAberration);

        // Get Lens Distortion
        volume.profile.TryGet(out lensDistortion);

        // Initialize tweeners
        chromaticTweener = DOTween.To(
            () => chromaticAberration.intensity.value, 
            x => chromaticAberration.intensity.value = x, 
            chromaticIntensityEnd, 
            feverTime)
            .From(chromaticIntensityStart)
            .SetLoops(-1, LoopType.Yoyo)
            .Pause();

        lensDistortionTweener = DOTween.To(
            () => lensDistortion.intensity.value, 
            x => lensDistortion.intensity.value = x, 
            lensDistortionIntensityEnd, 
            feverTime)
            .From(lensDistortionIntensityStart)
            .SetLoops(-1, LoopType.Yoyo)
            .Pause();
    }

    public void StartFeverEffect()
    {
        // Restart tweeners
        chromaticTweener.Play();
        lensDistortionTweener.Play();
    }

    public void StopFeverEffect()
    {
        // Pause tweeners
        chromaticTweener.Pause();
        lensDistortionTweener.Pause();
    }
}
