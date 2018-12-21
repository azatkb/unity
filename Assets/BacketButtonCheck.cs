using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class BacketButtonCheck : MonoBehaviour {

    public Sprite SuccessImage;
    public Sprite ErrorImage;

    public GameObject game0;
    public GameObject game1;
    public GameObject game2;
    public Button ReturnButton;
    public GameObject SuccessPanel;

    public int Numb;

    void Start () {

        if (ReturnButton != null){

            ReturnButton.onClick.AddListener(() => {

                game1.SetActive(false);
                game0.SetActive(true);

            });

        }

        gameObject.GetComponent<Button>().onClick.AddListener(() => {

            if(Numb == 3){
                gameObject.transform.parent.gameObject.GetComponent<Image>().sprite = SuccessImage;
                Invoke("Timeout", 2f);
                SuccessPanel.GetComponent<ElephantSuccess>().Success();
                //ColibriGame.Instance.Success();
            }
            else{
                gameObject.transform.parent.gameObject.GetComponent<Image>().sprite = ErrorImage;
                ColibriGame.Instance.Error();
            }

        });

    }

    void Timeout(){

        game1.SetActive(false);
        game2.SetActive(true);
        game2.GetComponent<Game5Behavior>().Init();


    }

}
