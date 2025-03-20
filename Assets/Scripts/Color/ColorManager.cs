using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameObject blue1;
    public GameObject blue2;
    public GameObject blue3;
    public GameObject blue4;
    public GameObject blue5;
    public GameManager gameManager;
    public int blueCount = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blueCount <= 0 && gameManager.allColorsPicked == false)
        {
            Debug.Log("You clicked on all the blue things!");
            gameManager.allColorsPicked = true;
            blueCount = 2;
            blue1.SetActive(true);
            blue2.SetActive(true);
            blue3.SetActive(true);
            blue4.SetActive(true);
            blue5.SetActive(true);
        }
    }
}
