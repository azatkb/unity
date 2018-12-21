using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SayPanel : MonoBehaviour {

    public GameObject Panel;

    public Button CloseButton;

    AudioSource audio;

    public AudioClip intro;

    public AudioClip intro_tj;

    void  Start(){ 

        gameObject.SetActive(false);

        this.audio = GetComponent<AudioSource>();

        Button btn = CloseButton.GetComponent<Button>();

        btn.onClick.AddListener(() => {

            gameObject.SetActive(false);

        });

    }

    public void PlaySound(){

        string language = PlayerPrefs.GetString("Language");

        gameObject.SetActive(true);

        AudioSource audio = GetComponent<AudioSource>();

        if (language.Length == 0) {
            language = "En";
        }

        if (language == "En") {
            audio.PlayOneShot(intro);
        }
        else
        {
            audio.PlayOneShot(intro_tj);
        }

    }

}
