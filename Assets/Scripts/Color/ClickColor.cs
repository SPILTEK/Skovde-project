using UnityEngine;
using TMPro;

public class PickColor : MonoBehaviour
{
    private TMP_Text blueText;
    public ColorManager colorManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorManager = GameObject.Find("GameManager").GetComponent<ColorManager>();
        blueText = GameObject.Find("BlueText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Blue") && colorManager.blueCount > 0)
        {
            Debug.Log("Clicked on " + gameObject.name);
            colorManager.blueCount--;
            blueText.text = "Click on " + colorManager.blueCount.ToString() + " blue things";
            // Insert additional logic here
            gameObject.SetActive(false);
        }
    }
}
