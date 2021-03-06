﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBookPreviewBehavior : MonoBehaviour {

    public GameObject Book;

    public Button ReadButton;

    public Button CloseButton;

    public AudioClip ClipTj;

    public AudioClip ClipEn;

    AudioSource BookName;

    public Button RecorButton;

    public Image BookImage;

    public Sprite ImageEn;

    public Sprite ImageTj;

    void  Start(){

        gameObject.SetActive(false);

        ReadButton.onClick.AddListener(() =>{

            Book.gameObject.SetActive(true);

            Book.GetComponent<DogBookReading>().StartReading();

            gameObject.SetActive(false);

            Assets.scripts.ColibriGame.Instance.Mute();

        });

        RecorButton.onClick.AddListener(() => {

            string language = PlayerPrefs.GetString("Language");

            if (language.Length == 0)
            {
                language = "En";
            }

            Assets.scripts.ColibriGame.Instance.StartRecording("DogBook" + language);

            Book.gameObject.SetActive(true);

            Book.GetComponent<DogBookReading>().StartReading();

            gameObject.SetActive(false);

            Assets.scripts.ColibriGame.Instance.Mute();

        });

        CloseButton.onClick.AddListener(() => {

            gameObject.SetActive(false);

            Assets.scripts.ColibriGame.Instance.ForseStopRecording();

        });

        BookName = gameObject.GetComponent<AudioSource>();

    }

    public void PlayName(){

        string language = PlayerPrefs.GetString("Language");

        BookName.Stop();


        if (language.Length == 0){
            language = "En";
        }

        if (language == "En"){
            BookName.PlayOneShot(ClipEn);
        }
        else{
            BookName.PlayOneShot(ClipTj);
        }

    }

}
