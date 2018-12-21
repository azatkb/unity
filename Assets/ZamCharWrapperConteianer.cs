using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamCharWrapperConteianer : MonoBehaviour {

    public GameObject game0;
    public GameObject game1;
    public GameObject game2;

    //public Button ReturnBautton;

    public GameObject SuccesPanel;

    public GameObject CharsPanel;

    AudioSource music;

    int SuccessCount = 0;

	void Start () {

        music = gameObject.GetComponent<AudioSource>();

    }

    public void Success(){

        SuccessCount ++;

        if(SuccessCount == 4){

            music.Play();

            Invoke("Timeout", 3f);

        }

    }

    void Timeout()
    {

        SuccesPanel.GetComponent<ZamSuccess>().Success();

        game1.SetActive(false);
        game2.SetActive(true);

        SuccessCount = 0;

        if (CharsPanel != null)
        {

            foreach (Transform child in CharsPanel.transform)
            {
                child.GetComponent<Assets.scripts.ZamGame3Char>().Reset();
            }

        }

    }


}
