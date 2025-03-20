using UnityEngine;
using UnityEngine.UI;

public class BreathingSquareTask : MonoBehaviour
{
    public Image breathingSquare; // The grid background
    public Slider topSlider, bottomSlider, leftSlider, rightSlider; // Sliders for each side
    private int currentSide = 0; // Tracks which side is being traced
    private bool taskCompleted = false;

    private void Awake()
    {
        bottomSlider.gameObject.SetActive(false);
        rightSlider.gameObject.SetActive(false);
        leftSlider.gameObject.SetActive(false);
    }
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
                case 0: 
                    
                        if (topSlider.value >= 1)
                    {
                        topSlider.interactable = false;
                        rightSlider.gameObject.SetActive(true);
                        currentSide++;
                    }

                    break;
                case 1:
                  
                        if (rightSlider.value >= 1)
                    {
                        rightSlider.interactable = false;
                        bottomSlider.gameObject.SetActive(true);
                        currentSide++;
                    }

                    break;
                case 2: 
                  
             
                        if (bottomSlider.value >= 1)
                    {
                        bottomSlider.interactable = false;
                        leftSlider.gameObject.SetActive(true);
                        currentSide++;
                    }

                    break;
                case 3: 
                        if (leftSlider.value >= 1)
                    {
                        topSlider.interactable = false;
                        CompleteTask();
                    }
                    
                    break;
            }
        }
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

