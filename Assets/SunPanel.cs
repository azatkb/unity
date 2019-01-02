using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class SunPanel: MonoBehaviour {

    public GameObject game0;

    public GameObject game1;

    public GameObject game2;

    public Button ReturnButton;

    public GameObject SuccessPanel;

    public GameObject CharsPanel;

    public int successMax;

    int SuccessCount = 0;

    void Start () {

        ReturnButton.onClick.AddListener(() =>
        {

            game0.SetActive(true);

            game1.SetActive(false);

        });

    }

    public void Success(){

        SuccessCount++;

        if(SuccessCount == successMax)
        {

            Invoke("Timeout", 2f);

        }
        else{
            ColibriGame.Instance.GreateJob();
        }

    }

    void Timeout()
    {

        SuccessPanel.GetComponent<OftobakSuccess>().Success();

        ColibriGame.Instance.GreateJob();

        game1.SetActive(false);

        game2.SetActive(true);

        SuccessCount = 0;

        if (CharsPanel != null)
        {

            foreach (Transform child in CharsPanel.transform)
            {
                child.GetComponent<Assets.scripts.LadyWordChar>().Reset();
            }

        }

        foreach (Transform child in transform)
        {
            child.GetComponent<SunWordItem>().Reset();
        }

    }

}
