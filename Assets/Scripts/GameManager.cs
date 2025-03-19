/*using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // References to your challenge scripts.
    // Assign these via the Inspector.
    public Shaking shakingChallenge;
    public Breathing breathingChallenge;
    public ChallengeHeartbeat heartbeatChallenge;

    // We'll store the challenges in an array for easy random selection.
    private Challenge[] challenges;

    // Time to wait before starting a challenge.
    public float delayBeforeChallenge = 3f;

    // Total rounds to run before ending the game.
    public int totalRounds = 10;
    private int currentRound = 0;

    private void Awake()
    {
        // Initialize the challenges array.
        challenges = new Challenge[] { shakingChallenge, breathingChallenge, heartbeatChallenge };
    }

    private void Start()
    {
        StartCoroutine(RunChallenges());
    }

    IEnumerator RunChallenges()
    {
        while (currentRound < totalRounds)
        {
            // Wait a few seconds before starting the next challenge.
            yield return new WaitForSeconds(delayBeforeChallenge);

            // (Optional) Reset all challenges before starting a new one.
            foreach (Challenge challenge in challenges)
            {
                challenge.ResetChallenge();
            }

            // Pick a random challenge.
            int randomIndex = Random.Range(0, challenges.Length);
            Challenge selectedChallenge = challenges[randomIndex];

            // Start the selected challenge by setting its start flag.
            selectedChallenge.startChallenge = true;
            Debug.Log("Starting challenge: " + selectedChallenge.gameObject.name);

            // Wait until the challenge signals that it is complete.
            yield return new WaitUntil(() => selectedChallenge.IsComplete);

            Debug.Log("Completed challenge: " + selectedChallenge.gameObject.name);
            currentRound++;
        }

        // After all rounds, load the end scene.
        SceneManager.LoadScene("EndScene");
    }
}
*/