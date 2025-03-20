using UnityEngine;
using UnityEngine.UI;

public class BreathingSquareTask : MonoBehaviour
{
    public Image breathingSquare; // The grid background
    public Slider topSlider, bottomSlider, leftSlider, rightSlider; // Sliders for each side
    private int currentSide = 0; // Tracks which side is being traced
    private bool taskCompleted = false;

    void Update()
    {
        if (!taskCompleted)
        {
            HandleTracing();
        }
    }

    void HandleTracing()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            switch (currentSide)
            {
                case 0: // Top Side
                    if (IsTouchingTop(touchPos))
                    {
                        topSlider.value += Time.deltaTime * 0.5f;
                        if (topSlider.value >= 1) currentSide++;
                    }
                    break;
                case 1: // Right Side
                    if (IsTouchingRight(touchPos))
                    {
                        rightSlider.value += Time.deltaTime * 0.5f;
                        if (rightSlider.value >= 1) currentSide++;
                    }
                    break;
                case 2: // Bottom Side
                    if (IsTouchingBottom(touchPos))
                    {
                        bottomSlider.value += Time.deltaTime * 0.5f;
                        if (bottomSlider.value >= 1) currentSide++;
                    }
                    break;
                case 3: // Left Side
                    if (IsTouchingLeft(touchPos))
                    {
                        leftSlider.value += Time.deltaTime * 0.5f;
                        if (leftSlider.value >= 1) CompleteTask();
                    }
                    break;
            }
        }
    }

    bool IsTouchingTop(Vector2 touchPos)
    {
        return touchPos.y > breathingSquare.transform.position.y + breathingSquare.rectTransform.rect.height / 2;
    }

    bool IsTouchingBottom(Vector2 touchPos)
    {
        return touchPos.y < breathingSquare.transform.position.y - breathingSquare.rectTransform.rect.height / 2;
    }

    bool IsTouchingLeft(Vector2 touchPos)
    {
        return touchPos.x < breathingSquare.transform.position.x - breathingSquare.rectTransform.rect.width / 2;
    }

    bool IsTouchingRight(Vector2 touchPos)
    {
        return touchPos.x > breathingSquare.transform.position.x + breathingSquare.rectTransform.rect.width / 2;
    }

    void CompleteTask()
    {
        taskCompleted = true;
        breathingSquare.gameObject.SetActive(false);
        topSlider.gameObject.SetActive(false);
        bottomSlider.gameObject.SetActive(false);
        leftSlider.gameObject.SetActive(false);
        rightSlider.gameObject.SetActive(false);
    }
}

