using UnityEngine;
using System.Collections;

public class CharacterSqueeze : MonoBehaviour
{
    // Squeeze factor: e.g., reducing width to 80% and increasing height to 120%
    public Vector2 squeezeFactor = new Vector2(0.8f, 1.2f);
    // Duration (in seconds) for one squeeze or unsqueeze phase.
    public float duration = 0.2f;
    // Total time (in seconds) for which the squeeze effect should repeat.
    public float repeatDuration = 2.0f;

    private Vector3 originalScale;
    private bool isRepeating = false;

    private void Start()
    {
        // Cache the original scale to return to it later.
        originalScale = transform.localScale;
        StartRepeatSqueeze();
    }

    /// <summary>
    /// Triggers a single squeeze and unsqueeze effect.
    /// </summary>
    public void SqueezeAndUnsqueeze()
    {
        StopAllCoroutines();
        StartCoroutine(SqueezeRoutine());
    }

    /// <summary>
    /// Coroutine that handles the squeeze and unsqueeze animation.
    /// </summary>
    private IEnumerator SqueezeRoutine()
    {
        Vector3 targetScale = new Vector3(
            originalScale.x * squeezeFactor.x,
            originalScale.y * squeezeFactor.y,
            originalScale.z
        );

        float elapsed = 0f;
        // Squeeze phase: Lerp from originalScale to targetScale.
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Unsqueeze phase: Lerp back to originalScale.
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }

    /// <summary>
    /// Starts the repeated squeeze effect for the duration specified by repeatDuration.
    /// </summary>
    public void StartRepeatSqueeze()
    {
        if (!isRepeating)
        {
            isRepeating = true;
            StartCoroutine(RepeatSqueezeRoutine());
        }
    }

    /// <summary>
    /// Stops the repeating squeeze effect.
    /// </summary>
    public void StopRepeatSqueeze()
    {
        isRepeating = false;
    }

    /// <summary>
    /// Coroutine that repeats the squeeze effect until the total repeatDuration elapses.
    /// </summary>
    private IEnumerator RepeatSqueezeRoutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < repeatDuration && isRepeating)
        {
            yield return SqueezeRoutine();
            // Each complete cycle (squeeze + unsqueeze) takes 2 * duration seconds.
            elapsedTime += 2 * duration;
        }
        // Ensure the scale resets after finishing.
        transform.localScale = originalScale;
        isRepeating = false;
    }
}