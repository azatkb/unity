using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVoiceBahavior : MonoBehaviour {

    private AudioSource source;

    public AudioClip en_1_1;
    public AudioClip en_1_2;
    public AudioClip en_1_3;
    public AudioClip en_1_4;


    public AudioClip tj_1_1;
    public AudioClip tj_1_2;
    public AudioClip tj_1_3;
    public AudioClip tj_1_4;

    private AudioClip[] clips;

    void Start(){

        this.source = gameObject.GetComponent<AudioSource>();

    }

    public void TranslateEn(){


        this.clips = new AudioClip[] { en_1_1, en_1_2, en_1_3, en_1_4 };

    }

    public void TranslateTj()
    {

        this.clips = new AudioClip[] { tj_1_1, tj_1_2, tj_1_3, tj_1_4 };

    }

    public void Play(int index ) {


        if (source.isPlaying){
            source.Stop();
        }

        source.PlayOneShot(clips[index-1]);
    }



}
