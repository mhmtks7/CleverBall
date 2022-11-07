using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;

    [SerializeField] private float Speed;

    Rigidbody fizik;

    int RandomSide;
    float RandomPos;
    float NegativePos;
    float PositvePos;

    int Scene›ndex;
    public int LastScene;

    public GameObject Continue;
    public Text SceneNumber;

    Rigidbody rb;

    GameObject ReklamObje;
    Reklam ReklamKontrol;

    
    public Text JumpText;
    bool JumpBool=true;

    public bool finishBool=false;
    public bool StartAnimationBool;

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        StartAnimationBool = true;
        ReklamObje = GameObject.FindGameObjectWithTag("Reklam");
        ReklamKontrol = ReklamObje.GetComponent<Reklam>();

        fizik = GetComponent<Rigidbody>();

        Scene›ndex = SceneManager.GetActiveScene().buildIndex;
        LastScene = PlayerPrefs.GetInt("Kayit");

        rb = GetComponent<Rigidbody>();

        JumpText.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        JumpText.text = ">";

        SceneStarting();

    }

    void FixedUpdate()
    {
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;

        Vector3 vec = (new Vector3(h, 0, v) * Time.deltaTime) * Speed;
        //transform.Translate(translate);

        fizik.AddForce(vec);
    }

    public void ContinueBut(string a)
    {
        if (a == "Menu")
        {
            SceneManager.LoadScene(0);
        }
        if (a == "PlayAgain")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (a == "Exit")
        {
            SceneManager.LoadScene(0);
        }
        if (a == "Jump" && JumpBool) 
        {
            StartAnimationBool = false;
            JumpBool = false;
            StartCoroutine(SkillMethod());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Space")
        {
            StartCoroutine(Loser());
        }
        if (other.tag == "Target")
        {
            StartCoroutine(Win());
        }
        
    }

    IEnumerator SkillMethod()
    {
        fizik.AddForce(new Vector3(0, 150, 0));
        JumpText.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        for (int i = 30; i > 0; i--)
        {
            JumpText.text = "" + i;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(.1f);
        JumpBool = true;
        JumpText.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        JumpText.text = ">";
    }

    IEnumerator Win()
    {
        rb.useGravity = false;
        rb.isKinematic = true;

        yield return new WaitForSeconds(1.5f);

        if (Scene›ndex==50)
        {
            finishBool = true;
        }
        else
        {
            SceneManager.LoadScene(Scene›ndex + 1);
        }
    }

    IEnumerator Loser()
    {
        yield return new WaitForSeconds(1f);
        rb.useGravity = false;
        rb.isKinematic = true;
        //AudioObje.SetActive(false);
        ReklamKontrol.GameOver();
        yield return new WaitForSeconds(1f);
        Continue.SetActive(true);
    }

    void SceneStarting()
    {
        if (Scene›ndex > LastScene) 
        {
            PlayerPrefs.SetInt("Kayit", Scene›ndex);
        }         

        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            NegativePos = -10f;
            PositvePos = 10f;
        }
        else if (SceneManager.GetActiveScene().buildIndex < 4)
        {
            NegativePos = -20f;
            PositvePos = 20f;
        }
        else if (SceneManager.GetActiveScene().buildIndex < 8)
        {
            NegativePos = -30f;
            PositvePos = 30f;
        }
        else if (SceneManager.GetActiveScene().buildIndex < 12)
        {
            NegativePos = -40f;
            PositvePos = 40f;
        }
        else if (SceneManager.GetActiveScene().buildIndex < 17)
        {
            NegativePos = -50f;
            PositvePos = 50f;
        }
        else if (SceneManager.GetActiveScene().buildIndex < 23)
        {
            NegativePos = -60f;
            PositvePos = 60f;
        }
        else 
        {
            NegativePos = -70f;
            PositvePos = 70f;
        }

        RandomSide = Random.Range(0, 4);
        RandomPos = Random.Range(NegativePos, PositvePos);

        switch (RandomSide)
        {

            case 0:
                transform.position = new Vector3(NegativePos, transform.position.y, RandomPos);
                break;
            case 1:
                transform.position = new Vector3(RandomPos, transform.position.y, PositvePos);
                break;
            case 2:
                transform.position = new Vector3(PositvePos, transform.position.y, RandomPos);
                break;
            case 3:
                transform.position = new Vector3(RandomPos, transform.position.y, NegativePos);
                break;
            default:
                break;
        }

        rb.isKinematic = false;
        rb.useGravity = true;
  

    }

}
