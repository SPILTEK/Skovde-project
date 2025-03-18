using UnityEngine;
using System.Collections;

public class CharacterShake : MonoBehaviour
{
    // Total duration of the shake effect
    public float shakeDuration = 0.5f;
    // Maximum deviation from the original position
    public float shakeMagnitude = 0.1f;
    // Lerp speed for smooth movement
    public float lerpSpeed = 10f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Coroutine currentShakeCoroutine;

    void Awake()
    {
        originalPosition = transform.localPosition;
        targetPosition = originalPosition;
    }

    private void Start()
    {
        // Start the shake effect when the game starts
        Shake();
    }

    // Starts the shake effect
    public void Shake()
    {
        // If a shake is already in progress, stop it first
        if (currentShakeCoroutine != null)
        {
            StopCoroutine(currentShakeCoroutine);
        }
        currentShakeCoroutine = StartCoroutine(ShakeCoroutine());
    }

    // Coroutine that applies the shake effect using Lerp
    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            // Choose a new random target offset if we're near the current target
            if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
            {
                Vector2 randomOffset = Random.insideUnitCircle * shakeMagnitude;
                targetPosition = originalPosition + new Vector3(randomOffset.x, randomOffset.y, 0);
            }

            // Smoothly interpolate towards the target position
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * lerpSpeed);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset position once shaking is done
        transform.localPosition = originalPosition;
        currentShakeCoroutine = null;
    }

    // Stops the shaking effect immediately and resets the position
    public void StopShaking()
    {
        if (currentShakeCoroutine != null)
        {
            StopCoroutine(currentShakeCoroutine);
            currentShakeCoroutine = null;
        }
        transform.localPosition = originalPosition;
    }
}