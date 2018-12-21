using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class App : MonoBehaviour {

    public  AudioClip music;

    public  AudioClip music2;

    public  AudioClip music3;

    public  AudioClip music4;

    public Button DefaultMusic;
  
    private AudioSource audioData;

    private AudioClip [] musics;

    AudioClip current;

    float oldVolume = 0;

    void Start () {

        audioData = GetComponent<AudioSource>();

        audioData.loop = true;

        this.musics = new AudioClip[] { music, music2, music3, music4 };

        this.StartMusic();

    }
 
    public  void StartMusic(int ? index = null){

        if(this.audioData.isPlaying){

            this.audioData.Stop();
        }

        //float? volume = PlayerPrefs.GetFloat("Volume");

        //if (volume != null)
        //{
        //    audioData.volume = (float)volume;
        //}
        //else
        //{
        //    audioData.volume = 0.5f;
        //}

        if (index != null){
            audioData.clip = this.musics[(int)index];
            current = this.musics[(int)index];
            audioData.Play();
        }
        else{
            current = music;
            audioData.clip = music3;
            audioData.Play();
            //DefaultMusic.gameObject.GetComponent<Animator>().Play("EqulizerAnimation");

        }

    }

    public void MuteMusic(){

        oldVolume = this.audioData.volume;

        this.audioData.volume = 0;

    }

    public void RecoverMusic(){
       
         if(oldVolume > 0){

            this.audioData.volume = oldVolume;

         }

    }



}
