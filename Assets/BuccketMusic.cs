using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuccketMusic : MonoBehaviour {

    public AudioSource music;

	void Start () {

        music = gameObject.GetComponent<AudioSource>();

        gameObject.GetComponent<Button>().onClick.AddListener(() => {

            music.Play();

        });

    }
	

}
