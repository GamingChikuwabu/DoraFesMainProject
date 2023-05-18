using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RandomBloomColor : MonoBehaviour
{
    public Volume volume;
    private Bloom bloom;

    public float colorChangeDuration = 1f;  // Color change duration in seconds

    private Color currentColor;
    private Color targetColor;

    private void Start()
    {
        // Get the Bloom component from the Volume
        if (volume.profile.TryGet<Bloom>(out var b))
        {
            bloom = b;
        }

        // Initialize current and target colors
        currentColor = bloom.tint.value;
        targetColor = GetRandomColor();

        // Start the coroutine that changes the bloom color
        StartCoroutine(ChangeBloomColor());
    }

    private IEnumerator ChangeBloomColor()
    {
        while (true)
        {
            float t = 0;  // Reset the 't' parameter

            while (t < colorChangeDuration)
            {
                // Increment 't' by the time since the last frame, divided by the duration
                t += Time.deltaTime / colorChangeDuration;

                // Lerp the bloom color from the current color to the target color
                bloom.tint.value = Color.Lerp(currentColor, targetColor, t);

                yield return null;  // Wait for the next frame
            }

            // Once the color change is complete, set the current color to the target color and generate a new target color
            currentColor = targetColor;
            targetColor = GetRandomColor();
        }
    }

    // Method to get a random color
    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
