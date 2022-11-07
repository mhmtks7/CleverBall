using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject Ball;

    public GameObject Effect;

    public GameObject FinishText;

    private void Start()
    {
        Effect.SetActive(false);
        FinishText.SetActive(false);
    }

    void LateUpdate()
    {
        if (Ball.GetComponent<BallScript>().finishBool == true)
        {
            Ball.GetComponent<BallScript>().finishBool = false;
            Effect.transform.position = Ball.transform.position;
            StartCoroutine(Finished());
        }
    }

    IEnumerator Finished()
    {
        Effect.SetActive(true);
        FinishText.SetActive(true);
        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(0);

    }
}
