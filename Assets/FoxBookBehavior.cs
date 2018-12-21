using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxBookBehavior : MonoBehaviour {

    public GameObject Book;

    public Button ReadButton;

    public Button CloseButton;

    public AudioClip ClipTj;

    public AudioClip ClipEn;

    public Button RecorButton;

    public Image BookImage;

    public Sprite ImageEn;

    public Sprite ImageTj;

    AudioSource BookName;

    void  Start(){

        gameObject.SetActive(false);

        ReadButton.onClick.AddListener(() =>{

            Book.gameObject.SetActive(true);

            Book.GetComponent<FoxBookReading>().StartReading();

            gameObject.SetActive(false);

            Assets.scripts.ColibriGame.Instance.Mute();

        });

        CloseButton.onClick.AddListener(() => {

            gameObject.SetActive(false);

            Assets.scripts.ColibriGame.Instance.ForseStopRecording();

        });

        RecorButton.onClick.AddListener(() => {

            string language = PlayerPrefs.GetString("Language");

            if (language.Length == 0)
            {
                language = "En";
            }

            Assets.scripts.ColibriGame.Instance.StartRecording("FoxBook"+ language);

            Book.gameObject.SetActive(true);

            Book.GetComponent<FoxBookReading>().StartReading();

            gameObject.SetActive(false);

            Assets.scripts.ColibriGame.Instance.Mute();

        });

        BookName = gameObject.GetComponent<AudioSource>();

    }

    public void PlayName()
    {

        string language = PlayerPrefs.GetString("Language");

        BookName.Stop();

        if (language.Length == 0)
        {
            language = "En";
        }

        if (language == "En")
        {
            BookName.PlayOneShot(ClipEn);
        }
        else
        {
            BookName.PlayOneShot(ClipTj);
        }

    }

}
