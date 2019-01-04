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

    public AudioClip en_2_1;
    public AudioClip en_2_2;
    public AudioClip en_2_3;
    public AudioClip en_2_4;

    public AudioClip tj_2_1;
    public AudioClip tj_2_2;
    public AudioClip tj_2_3;
    public AudioClip tj_2_4;

    public AudioClip en_3_1;
    public AudioClip en_3_2;
    public AudioClip en_3_3;
    public AudioClip en_3_4;
    public AudioClip en_3_5;

    public AudioClip tj_3_1;
    public AudioClip tj_3_2;
    public AudioClip tj_3_3;
    public AudioClip tj_3_4;
    public AudioClip tj_3_5;

    public AudioClip en_4_1;
    public AudioClip en_4_2;
    public AudioClip en_4_3;
    public AudioClip en_4_4;

    public AudioClip tj_4_1;
    public AudioClip tj_4_2;
    public AudioClip tj_4_3;
    public AudioClip tj_4_4;

    public AudioClip en_5_1;
    public AudioClip en_5_2;
    public AudioClip en_5_3;
    public AudioClip en_5_4;

    public AudioClip tj_5_1;
    public AudioClip tj_5_2;
    public AudioClip tj_5_3;
    public AudioClip tj_5_4;

    private AudioClip[] clips;

    int index;

    void Start(){

        this.source = gameObject.GetComponent<AudioSource>();

    }

    public void TranslateEn(){

        this.clips = new AudioClip[] { en_1_1, en_1_2, en_1_3, en_1_4, en_2_1, en_2_2, en_2_3, en_2_4
                                     , en_3_1, en_3_2, en_3_3, en_3_4, en_3_5, en_4_1, en_4_2, en_4_3, en_4_4,en_5_1, en_5_2, en_5_3, en_5_4};

    }

    public void TranslateTj(){

        this.clips = new AudioClip[] { tj_1_1, tj_1_2, tj_1_3, tj_1_4, tj_2_1, tj_2_2, tj_2_3, tj_2_4
                                     , tj_3_1, tj_3_2, tj_3_3, tj_3_4, tj_3_5 , tj_4_1, tj_4_2, tj_4_3, tj_4_4 , tj_5_1, tj_5_2, tj_5_3, tj_5_4 };

    }

    public void Play(int index ) {

        if (source.isPlaying){
            source.Stop();
        }

        Invoke("Timeout", 1f);

        this.index = index;
    }

    void Timeout(){

        source.PlayOneShot(clips[index - 1]);

    }





}
