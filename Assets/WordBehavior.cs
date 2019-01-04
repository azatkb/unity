using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBehavior : MonoBehaviour {

    int SuccesCount = 0;
    public GameObject game1;
    public GameObject game2;
    //public Button ReturnButton;
    public GameObject SuccessPanel;

    public GameObject CharsPanel;

    public int successCount;

    void Start () {

        //ReturnButton.onClick.AddListener(() => {

        //    game1.SetActive(false);
        
        //});

    }
	
	void Update () {
		
	}

    public void Succes(){

        SuccesCount++;
       
        if(SuccesCount == successCount)
        {

            SuccessPanel.GetComponent<ElephantSuccess>().Success();

            Invoke("Timeout", 2f);

        }
        else{

            Assets.scripts.ColibriGame.Instance.Success();
        }

    }


    void Timeout(){

        game1.SetActive(false);
        game2.SetActive(true);

        Assets.scripts.ColibriGame.Instance.GameVoice(2);

        SuccesCount = 0;

        foreach (Transform child in transform)
        {
            child.GetComponent<Assets.scripts.WordItem>().Reset();
        }

        if(CharsPanel != null){

            foreach (Transform child in CharsPanel.transform)
            {
                child.GetComponent<Assets.scripts.WordChar>().Reset();
            }

        }

    }
}
