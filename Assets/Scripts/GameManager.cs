using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int challange = 0;
    private int challangesCompleted = 0;
    public bool allColorsPicked = false;

    public GameObject hahaBubble;
    public GameObject questionsBubble;
    public GameObject yellBubble;
    public GameObject pickColorBlue;

    public Heartbeat heartbeat;
    public Shaking shaking;

    private void Awake()
    {
        hahaBubble.SetActive(false);
        questionsBubble.SetActive(false);
        yellBubble.SetActive(false);
        pickColorBlue.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(ChooseChallange());
    }

    private void Update()
    {
        if (allColorsPicked)
        {
            StartCoroutine(NormalizeHeartbeat());
        }
    }

    private IEnumerator ChooseChallange()
    {
        yield return new WaitForSeconds(5);
        //challange = Random.Range(1, 4);
        challange = 1;
        switch (challange)
        {
            case 1:
                print("Heartbeat");
                hahaBubble.SetActive(true);
                yield return new WaitForSeconds(1);
                heartbeat.SetFastHeartbeat();
                yield return new WaitForSeconds(2);
                pickColorBlue.SetActive(true);
                break;
            case 2:
                print("Hyperventilate");
                questionsBubble.SetActive(true);
                yield return new WaitForSeconds(3);
                questionsBubble.SetActive(false);
                StartCoroutine(ChooseChallange());
                break;
            case 3:
                print("Shaking");
                yellBubble.SetActive(true);
                yield return new WaitForSeconds(3);
                shaking.Shake();
                bool stopShaking = false;
                // Wait until the player touches the screen (or clicks the mouse)
                while (!stopShaking)
                {
                    // For mobile devices: detect a touch beginning
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        shaking.StopShaking();
                        stopShaking = true;
                    }
                    // For testing in the editor (desktop): detect a mouse click
                    if (Input.GetMouseButtonDown(0))
                    {
                        shaking.StopShaking();
                        stopShaking = true;
                    }
                    yield return null; // Wait for the next frame
                }
                yellBubble.SetActive(false);
                yield return new WaitForSeconds(3);
                StartCoroutine(ChooseChallange());
                break;
            default:
                print("Incorrect intelligence level.");
                StartCoroutine(ChooseChallange());
                break;
        }
    }
    private IEnumerator NormalizeHeartbeat()
    {
        heartbeat.SetNormalHeartbeat();
        hahaBubble.SetActive(false);
        pickColorBlue.SetActive(false);
        allColorsPicked = false;
        yield return new WaitForSeconds(3);
        StartCoroutine(ChooseChallange());
    }

}