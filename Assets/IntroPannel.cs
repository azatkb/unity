using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPannel : MonoBehaviour{ 

	public Button OkButton;

    public GameObject Panel;

    public AudioClip sount;

    public AudioClip tj_sount;

    AudioSource audio;

    void Start() {

        gameObject.SetActive(false);

        audio = gameObject.GetComponent<AudioSource>();

        OkButton.onClick.AddListener(() =>
        {

            //Panel.SetActive(true);
            //gameObject.SetActive(false);
            //Panel.GetComponent<GrowPannel>().PlayIntro();

        });

    }

    public void PlaySound(){

        string language = PlayerPrefs.GetString("Language");

        if (language.Length == 0)
        {
            language = "En";
        }

        if(language == "En"){

            audio.PlayOneShot(sount);

        }else{

            audio.PlayOneShot(tj_sount);
        }


    }

}
