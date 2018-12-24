using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceBahavior : MonoBehaviour {

    private AudioSource source;

    AudioClip error;

    public AudioClip oops;

    public AudioClip oops_tj;

    public AudioClip perfect;

    public AudioClip greateJob;

    public AudioClip ewesome;

    public AudioClip fantastic;

    public AudioClip greate;

    public AudioClip wonderful;


    public AudioClip perfect_tj;

    public AudioClip greateJob_tj;

    public AudioClip ewesome_tj;

    public AudioClip fantastic_tj;

    public AudioClip greate_tj;

    public AudioClip wonderful_tj;

    private AudioClip[] clips;

    private AudioClip[] clips_error;

    private string [] clipsTexts;

    public Text successText1;
    public Text successText2;
    public Text successText3;
    public Text successText4;
    public Text successText5;

    void Start(){

        this.source = gameObject.GetComponent<AudioSource>();

    }

    public void TranslateEn(){

        this.clipsTexts = new string[] { "PERFECT!", "GREAT JOB!", "AWESOME!", "FANTASTIC!", "GOOD JOB! ", "WONDERFUL!" };

        this.clips = new AudioClip[] { perfect, greateJob, ewesome, fantastic, greate, wonderful };

        this.error = oops;

    }

    public void TranslateTj()
    {
   
        this.clipsTexts = new string[] { "Беҳтарин!", "Олӣ!", "Аҳсан!", "Аҷоиб!", "Бисёр нағз!", "Олиҷаноб!" };

        this.clips = new AudioClip[] { perfect_tj, greateJob_tj, ewesome_tj, fantastic_tj, greate_tj, wonderful_tj };

        this.error = oops_tj;

    }

    public void Success(int ? index = null) {

        if(index ==  null){

            index = Random.Range(0, 5);

        }

        successText1.text = clipsTexts[(int)index];
        successText2.text = clipsTexts[(int)index];
        successText3.text = clipsTexts[(int)index];
        //successText4.text = clipsTexts[(int)index];
        //successText5.text = clipsTexts[(int)index];

        if (source.isPlaying){
            source.Stop();
        }

        source.PlayOneShot(clips[(int)index]);
    }

    public void Error(){

        source.PlayOneShot(error);

    }

    public void GreateJob(int? index = null) {

        if (source.isPlaying){
            source.Stop();
        }

        if (index == null){

            index = Random.Range(0, 5);

        }

        successText1.text = clipsTexts[(int)index];
        successText2.text = clipsTexts[(int)index];
        successText3.text = clipsTexts[(int)index];
        //successText4.text = clipsTexts[(int)index];
        //successText5.text = clipsTexts[(int)index];

        source.PlayOneShot(clips[(int)index]);

    }

    public void Ewesome(int? index = null) {

        if (source.isPlaying){
            source.Stop();
        }
        if (index == null)
        {

            index = Random.Range(0, 5);

        }

        successText1.text = clipsTexts[(int)index];
        successText2.text = clipsTexts[(int)index];
        successText3.text = clipsTexts[(int)index];
        //successText4.text = clipsTexts[(int)index];
        //successText5.text = clipsTexts[(int)index];

        source.PlayOneShot(clips[(int)index]);
    }

    public void Mute(){

        Debug.Log("Mute");
        Debug.Log(source.volume);
        source.volume = 0f;
        Debug.Log(source.volume);



        //source.volume = 0f;

    }

}
