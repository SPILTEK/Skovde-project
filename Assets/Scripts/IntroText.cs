using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    // Reference to the UI Text component that displays the text.
    public TMP_Text displayText;

    // Array of text messages to display.
    public string[] texts;

    // Array of durations (in seconds) for each text.
    // Ensure that texts and durations arrays have the same length.
    public float[] durations;

    // Set to true if you want the text display to loop.
    public bool loop = false;

    void Start()
    {
        // Check for array length mismatch.
        if (texts.Length != durations.Length)
        {
            Debug.LogError("The texts and durations arrays must have the same length.");
            return;
        }

        // Start the coroutine that cycles through the text list.
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        do
        {
            // Iterate over each text entry.
            for (int i = 0; i < texts.Length; i++)
            {
                // Set the UI Text element to the current text.
                displayText.text = texts[i];

                // Wait for the specified duration before showing the next text.
                yield return new WaitForSeconds(durations[i]);
            }
        } while (loop);

        // Optionally, clear the text once the sequence is done.
        displayText.text = "";
    }
}