using UnityEngine;
using DG.Tweening;

public class TreeSwing : MonoBehaviour
{
    public float scaleChangeDuration = 2f; // The duration of the scale change
    public float maxScaleY = 2f; // The maximum scale value in the Y axis

    public float swingDuration = 2f; // The duration of the swing
    public float maxSwingAngle = 30f; // The maximum swing angle in degrees

    public void Start()
    {
        // Store the initial scale
        Vector3 initialScale = transform.localScale;

        // Change the scale in the Y axis over time
        DOTween.To(() => transform.localScale, x => transform.localScale = x, new Vector3(initialScale.x, maxScaleY, initialScale.z), scaleChangeDuration)
            .SetLoops(-1, LoopType.Yoyo); // Repeat indefinitely, going back and forth between the initial and final values

        // Swing the tree left and right over time
        transform.DORotate(new Vector3(0, 0, maxSwingAngle), swingDuration)
            .SetLoops(-1, LoopType.Yoyo) // Repeat indefinitely, going back and forth between the initial and final values
            .SetEase(Ease.InOutSine); // Use a sine function for a smooth, natural motion
    }
}
