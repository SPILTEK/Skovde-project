using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public int blueCount = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blueCount <= 0)
        {
            Debug.Log("You clicked on all the blue things!");
        }
    }
}
