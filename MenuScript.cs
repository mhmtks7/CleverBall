using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Levels;
    public GameObject Back;
    public GameObject ButAudio;
    public GameObject AudioObje;
    public GameObject SettingMenu;
    public GameObject AudioImage;

    public Slider SliderObje;

    public Sprite[] AudioSprite;

    int SliderCount;

    int LastScene;

    bool AudioBool;

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        Levels.SetActive(false);
        Back.SetActive(false);
        Menu.SetActive(true);
        ButAudio.SetActive(false);
        SettingMenu.SetActive(false);

        if (PlayerPrefs.HasKey("AudioRecord"))
        {
            SliderObje.value = PlayerPrefs.GetFloat("AudioRecord");
        }
        else
        {
            SliderObje.value = 3f;
        }
        SliderBut();

        LastScene = PlayerPrefs.GetInt("Kayit");
        AudioBool = true;
        SceneLevels();
    }

    public void MenuButtons(string incoming)
    {
        if (incoming == "Continue")
        {
            if (LastScene > 0)
            {
                ButAudio.SetActive(false);
                ButAudio.SetActive(true);
                SceneManager.LoadScene(LastScene);
            }
            else
            {
                ButAudio.SetActive(false);
                ButAudio.SetActive(true);
                SceneManager.LoadScene(1);
            }
        }
        if (incoming == "Start")
        {
            ButAudio.SetActive(false);
            ButAudio.SetActive(true);
            SceneManager.LoadScene(1);

        }
        if (incoming == "Levels")
        {
            ButAudio.SetActive(false);
            ButAudio.SetActive(true);
            Menu.SetActive(false);
            Back.SetActive(true);
            Levels.SetActive(true);
            
        }
        if (incoming == "Back")
        {
            ButAudio.SetActive(false);
            ButAudio.SetActive(true);
            Levels.SetActive(false);
            SettingMenu.SetActive(false);
            Back.SetActive(false);
            Menu.SetActive(true);
        }
        if (incoming == "Exit")
        {
            Application.Quit();
        }
        

        if (incoming == "Setting")
        {
            ButAudio.SetActive(false);
            ButAudio.SetActive(true);
            Menu.SetActive(false);
            Back.SetActive(true);
            SettingMenu.SetActive(true);
        }
    }

    public void SliderBut()
    {
        Debug.Log(SliderObje.value);
        PlayerPrefs.SetFloat("AudioRecord", SliderObje.value);
        SliderCount = int.Parse("" + SliderObje.value);
        AudioImage.GetComponent<Image>().sprite = AudioSprite[SliderCount];
        AudioObje.GetComponent<AudioSource>().volume = SliderObje.value / 5;
    }

    public void Level(int Number)
    {
        ButAudio.SetActive(false);
        ButAudio.SetActive(true);
        SceneManager.LoadScene(Number);
    }

    void SceneLevels()
    {
        Debug.Log(LastScene);
        Debug.Log(Levels.transform.childCount);
        for (int i = 0; i < Levels.transform.childCount; i++)
        {
            Levels.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        for (int j = 0; j < LastScene; j++)
        {
            Levels.transform.GetChild(j).GetComponent<Button>().interactable = true;
        }
    }

}
