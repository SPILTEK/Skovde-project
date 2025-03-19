using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class IntroText : MonoBehaviour
{
    // Reference to the UI Text component that displays the text.
    public TMP_Text displayText;

    // Array of text messages to display.
    public string[] texts;
    int index = 0;
    bool allTextsDisplayed = false;

    void Start()
    {
        displayText.text = texts[index];
        index++;
    }

    void OnMouseDown()
    {
        if (index < texts.Length)
        {
            displayText.text = texts[index];
            index++;
        }
        else
        {
            SceneManager.LoadScene("MadsTest");
        }
    }
}