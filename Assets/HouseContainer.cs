using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseContainer : MonoBehaviour {

    public GameObject game0;
    public GameObject game1;
    public GameObject game2;

    public Button ReturnBautton;

    public GameObject SuccesPanel;

    private AudioSource sm;

    public GameObject CharsPanel;

    int SuccessCount = 0;

    void Start(){

        sm = gameObject.GetComponent<AudioSource>();

        ReturnBautton.onClick.AddListener(() =>
        {

            game1.gameObject.SetActive(false);
            game0.gameObject.SetActive(true);

        });

    }

    public void Success(){
     
        sm.Play();

        SuccessCount++;

        if (SuccessCount == 7) {

            Invoke("Timeout", 2f);

            Assets.scripts.ColibriGame.Instance.Ewesome();

            SuccesPanel.GetComponent<ZamSuccess>().Success();

        }

    }

    void Timeout()
    {


        game1.SetActive(false);
        game2.SetActive(true);

        SuccessCount = 0;

        if (CharsPanel != null)
        {

            foreach (Transform child in CharsPanel.transform)
            {
                child.GetComponent<HouseItemDraggable>().Reset();
            }

        }

    }

}
