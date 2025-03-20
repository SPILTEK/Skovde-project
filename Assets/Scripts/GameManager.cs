using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int challange = 0;
    private int challangesCompleted = 0;

    private void Start()
    {
        StartCoroutine(ChooseChallange());
    }

    private void Update()
    {

    }

    private IEnumerator ChooseChallange()
    {
        challange = Random.Range(1, 4);
        switch (challange)
        {
            case 1:
                print("1");
                yield return new WaitForSeconds(3);
                StartCoroutine(ChooseChallange());
                break;
            case 2:
                print("2");
                yield return new WaitForSeconds(3);
                StartCoroutine(ChooseChallange());
                break;
            case 3:
                print("3");
                yield return new WaitForSeconds(3);
                StartCoroutine(ChooseChallange());
                break;
            default:
                print("Incorrect intelligence level.");
                StartCoroutine(ChooseChallange());
                break;
        }
    }
}