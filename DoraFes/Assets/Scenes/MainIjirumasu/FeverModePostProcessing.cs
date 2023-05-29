using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FeverModePostProcessing : MonoBehaviour
{
    public Volume postProcessingVolume;

    // Bloom
    public bool enableBloom;
    public float bloomIntensity;

    // Color Grading
    public bool enableColorGrading;
    public float saturation;
    public float contrast;

    //grayscale

    // Vignette
    public bool enableVignette;
    public float vignetteIntensity;

    // Motion Blur
    public bool enableMotionBlur;
    public float motionBlurIntensity;

    private Bloom bloom;
    private ColorAdjustments colorAdjustments;
    private Vignette vignette;
    private MotionBlur motionBlur;

    void Start()
    {
        postProcessingVolume.profile.TryGet(out bloom);
        postProcessingVolume.profile.TryGet(out colorAdjustments);
        postProcessingVolume.profile.TryGet(out vignette);
        postProcessingVolume.profile.TryGet(out motionBlur);
    }

    void Update()
    {
        if (enableBloom)
        {
            bloom.intensity.value = bloomIntensity;
        }

        if (enableColorGrading)
        {
            colorAdjustments.saturation.value = saturation;
            colorAdjustments.contrast.value = contrast;
        }

        if (enableVignette)
        {
            vignette.intensity.value = vignetteIntensity;
        }

        if (enableMotionBlur)
        {
            motionBlur.intensity.value = motionBlurIntensity;
        }
    }
}
