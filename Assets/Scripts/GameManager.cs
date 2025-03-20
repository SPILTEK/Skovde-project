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
    public GameObject breathingContainer;
    public GameObject challangesCompletedText;

    public Heartbeat heartbeat;
    public Shaking shaking;
    public Breathing breathing;
    public BreathingSquareTask breathingSquareTask;

    public AudioClip heartbeatAudio;

    public AudioSource audioSource;

    private void Awake()
    {
        hahaBubble.SetActive(false);
        questionsBubble.SetActive(false);
        yellBubble.SetActive(false);
        pickColorBlue.SetActive(false);
        breathingContainer.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(ChooseChallange());
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        if (allColorsPicked)
        {
            StartCoroutine(NormalizeHeartbeat());
        }
        if (breathingSquareTask.taskCompleted)
        {
            StartCoroutine(ResetBreathing());
        }
        if (challangesCompleted >= 10)
        {
            SceneManager.LoadScene("Ending");
        }
    }

    private IEnumerator ChooseChallange()
    {
        challangesCompletedText.GetComponent<TMPro.TextMeshProUGUI>().text = challangesCompleted.ToString();
        challangesCompleted++;
        yield return new WaitForSeconds(2);
        //challange = Random.Range(1, 4);
        challange = 2;
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
                yield return new WaitForSeconds(1);
                breathing.StartRepeatSqueeze();
                yield return new WaitForSeconds(2);
                breathingContainer.SetActive(true);

                break;
            case 3:
                print("Shaking");
                yellBubble.SetActive(true);
                yield return new WaitForSeconds(1);
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
                yield return new WaitForSeconds(1);
                StartCoroutine(ChooseChallange());
                break;
            default:
                print("Wrong index");
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
        yield return new WaitForSeconds(2);
        StartCoroutine(ChooseChallange());
    }

    private IEnumerator ResetBreathing()
    {
        breathingContainer.SetActive(false);
        questionsBubble.SetActive(false);
        breathing.StopRepeatSqueeze();
        breathingSquareTask.taskCompleted = false;
        yield return new WaitForSeconds(2);
        StartCoroutine(ChooseChallange());
    }
}