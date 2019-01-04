using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class OrzuiCharsWrapper : MonoBehaviour {

    int SuccessCount = 0;

    public GameObject game0;

    public GameObject game1;

    public GameObject game2;

    public GameObject SuccessPanel;

    public Button ReturnButton;

    public GameObject CharsPanel;

    void Start () {

        ReturnButton.onClick.AddListener(() =>
        {

            game1.SetActive(false);

            game0.SetActive(true);

            Assets.scripts.ColibriGame.Instance.GameVoice(14);

        });

    }

    public void Success(){

        SuccessCount++;

        if (SuccessCount == 3){

            Invoke("Timeout", 3f);

            SuccessPanel.GetComponent<DogSuccess>().Success();

        }else{

            ColibriGame.Instance.GreateJob();

        }

    }

    void Timeout()
    {

        game1.SetActive(false);
        game2.SetActive(true);

        Assets.scripts.ColibriGame.Instance.GameVoice(16);

        SuccessCount = 0;

        if (CharsPanel != null)
        {

            foreach (Transform child in CharsPanel.transform)
            {
                child.GetComponent<OrzuiWordChar>().Reset();
            }

        }


    }


}
