using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPannel : MonoBehaviour{ 

	public Button OkButton;
	public Button OkButton2;
    public GameObject Panel;
    public GameObject SyaPanel;
    //public GameObject IntroDescription;

    public GameObject GrowUpPanel1;
    public GameObject GrowUpPanel2;

    public AudioClip voice;
    public AudioClip voice_tj;
    public AudioClip voice2;
    public AudioClip voice2_tj;
    private AudioSource Sources;

    public void PlayIntro(){

        string language = PlayerPrefs.GetString("Language");

        if (language.Length == 0)
        {
            language = "En";
        }

        if (language == "En"){

            Sources.PlayOneShot(voice);

        }
        else {

            Sources.PlayOneShot(voice_tj);
        }


    }

    void Start() {

        this.Sources = GetComponent<AudioSource>();

        gameObject.SetActive(false);

        GrowUpPanel2.SetActive(false);

        Sources.PlayOneShot(voice);

        OkButton.onClick.AddListener(() =>
        {

            GrowUpPanel1.SetActive(false);

            GrowUpPanel2.SetActive(true);

            if (Sources.isPlaying)
            {

                Sources.Stop();

            }

            string language = PlayerPrefs.GetString("Language");

            if (language.Length == 0)
            {
                language = "En";
            }

            if (language == "En")
            {
                Sources.PlayOneShot(voice2);

            }
            else
            {
                Sources.PlayOneShot(voice2_tj);
            }

        });

        OkButton2.onClick.AddListener(() =>
        {

            Panel.SetActive(true);

            gameObject.SetActive(false);

            Panel.GetComponent<MainScreen>().State();

            SyaPanel.SetActive(true);

            SyaPanel.GetComponent<SayPanel>().PlaySound();


        });

    }

}
