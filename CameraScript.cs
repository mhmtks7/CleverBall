using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;
    float h, v;

    public GameObject Ball;
    GameObject Continous;
    Text Countdown;
    Text SceneNumber;
    GameObject AudioObje;
    GameObject JumpBut;
    bool StartingStatu;

    int SceneNo;

    GameObject StartAnimation;
    GameObject JumpAnimation;
    GameObject SkipButon;

    bool SkipBool;

    void Start()
    {
        AudioObje = GameObject.FindGameObjectWithTag("Audio");
        Continous = GameObject.FindGameObjectWithTag("Cont");
        JumpBut = GameObject.FindGameObjectWithTag("Jump");
        SkipButon = GameObject.FindGameObjectWithTag("Skip");
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartAnimation = GameObject.FindGameObjectWithTag("Promotion");
            JumpAnimation = GameObject.FindGameObjectWithTag("JumpAnime");
            StartAnimation.SetActive(false);
            JumpAnimation.SetActive(false);
        }
        

        Countdown = GameObject.FindGameObjectWithTag("Coundown").GetComponent<Text>();
        SceneNumber = GameObject.FindGameObjectWithTag("SceneNumber").GetComponent<Text>();
        Countdown.gameObject.SetActive(true);
        StartingStatu = false;
        Countdown.gameObject.SetActive(true);

        SkipBool = true;

        SceneNo = SceneManager.GetActiveScene().buildIndex;

        SceneNumber.text = "Level :" + SceneNo;
        
        StartCoroutine(Starting());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (StartingStatu)
        {
            transform.position = Ball.transform.position + new Vector3(0, 3, 0);
        }
        v = Joystick.Vertical; //get the vertical value of joystick
        h = Joystick.Horizontal;
    }

    public void SkipBut(string incoming)
    {
        if (incoming == "Skip")
        {
            SkipBool = false;
        }
    }

    IEnumerator Starting()
    {
        Ball.SetActive(false);
        Continous.SetActive(false);
        AudioObje.SetActive(false);
        AudioObje.SetActive(true);
       
        JumpBut.GetComponent<Button>().enabled = false;
        SkipButon.SetActive(true);
        if (SceneNo < 2)
        {
            transform.position = new Vector3(0, 30, 0);
        }
        else if (SceneNo < 4)
        {
            transform.position = new Vector3(0, 50, 0);
        }
        else if (SceneNo < 8)
        {
            transform.position = new Vector3(0, 70, 0);
        }
        else if (SceneNo < 12)
        {
            transform.position = new Vector3(0, 90, 0);
        }
        else if (SceneNo < 17)
        {
            transform.position = new Vector3(0, 110, 0);
        }
        else if (SceneNo < 23)
        {
            transform.position = new Vector3(0, 130, 0);
        }
        else
        {
            transform.position = new Vector3(0, 150, 0);
        }

        for (int i = 5; i > 0; i--)
        {
            if (SkipBool)
            {
                Countdown.text = "" + i;
                yield return new WaitForSeconds(1f);
            }    
        }
        SkipButon.SetActive(false);
        Countdown.gameObject.SetActive(false);
        JumpBut.GetComponent<Button>().enabled = true;
        Ball.SetActive(true);
        StartingStatu = true;

        if (SceneNo == 1)
        {
            yield return new WaitForSeconds(1f);
            while (true)
            {
                if (v == 0 && h == 0)
                {
                    StartAnimation.SetActive(true);
                    yield return new WaitForSeconds(.5f);
                    StartAnimation.SetActive(false);
                    yield return new WaitForSeconds(.3f);
                }
                
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (Ball.GetComponent<BallScript>().StartAnimationBool == true)
                {
                    JumpAnimation.SetActive(true);
                    yield return new WaitForSeconds(.5f);
                    JumpAnimation.SetActive(false);
                    yield return new WaitForSeconds(.3f);
                }
                else
                {
                    break;
                }
            }
        }
    }


}
