using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    // Parameters for normal heartbeat.
    public float normalSpeed = 2.0f;
    public float normalScaleAmount = 0.2f;

    // Parameters for fast heartbeat.
    public float fastSpeed = 4.0f;
    public float fastScaleAmount = 0.3f;

    // Current heartbeat parameters.
    private float currentSpeed;
    private float currentScaleAmount;

    private RectTransform rectTransform;
    private Vector3 initialScale;
    private Vector2 initialAnchoredPosition;

    void Start()
    {
        // Get the RectTransform component attached to the UI element.
        rectTransform = GetComponent<RectTransform>();
        // Ensure the pivot is at the center for proper scaling.
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        // Store the initial scale and anchored position.
        initialScale = rectTransform.localScale;
        initialAnchoredPosition = rectTransform.anchoredPosition;

        // Set the default heartbeat to normal.
        SetNormalHeartbeat();
    }

    void Update()
    {
        // Calculate a pulsating scale factor using Mathf.PingPong.
        float scaleFactor = 1 + Mathf.PingPong(Time.time * currentSpeed, currentScaleAmount);
        // Apply the scaling.
        rectTransform.localScale = initialScale * scaleFactor;
        // Reapply the original anchored position to ensure the heart stays in place.
        rectTransform.anchoredPosition = initialAnchoredPosition;
    }

    // Public function to set a normal heartbeat.
    public void SetNormalHeartbeat()
    {
        currentSpeed = normalSpeed;
        currentScaleAmount = normalScaleAmount;
    }

    // Public function to set a fast heartbeat.
    public void SetFastHeartbeat()
    {
        currentSpeed = fastSpeed;
        currentScaleAmount = fastScaleAmount;
    }
}
