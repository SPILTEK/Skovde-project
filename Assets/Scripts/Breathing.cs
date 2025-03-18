using UnityEngine;
using System.Collections;

public class Breathing : MonoBehaviour
{
    // The factor to apply when squeezing:
    // For example, 0.8f on X will reduce width, and 1.2f on Y will increase height.
    public Vector2 squeezeFactor = new Vector2(0.8f, 1.2f);

    // Duration (in seconds) for both squeezing and unsqueezing phases.
    public float duration = 0.2f;

    private Vector3 originalScale;

    private void Start()
    {
        // Store the original scale so we can return to it later.
        originalScale = transform.localScale;
        SqueezeAndUnsqueeze();
    }

    // Call this method to trigger the squeeze effect.
    public void SqueezeAndUnsqueeze()
    {
        StopAllCoroutines(); // Ensure no other squeeze is running.
        StartCoroutine(SqueezeRoutine());
    }

    private IEnumerator SqueezeRoutine()
    {
        // Calculate the target scale using the provided squeeze factors.
        Vector3 targetScale = new Vector3(originalScale.x * squeezeFactor.x, originalScale.y * squeezeFactor.y, originalScale.z);
        float elapsed = 0f;

        // First phase: Squeeze (transition to the target scale).
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Second phase: Unsqueeze (transition back to the original scale).
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }
}