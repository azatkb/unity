using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxWordBehavior : MonoBehaviour {

    int SuccesCount = 0;
    public GameObject game1;
    public GameObject game2;
    public GameObject SuccessPanel;

    public GameObject CharsPanel;

    public int sCount;

    void Start () {

    }
	
	void Update () {
		
	}

    public void Succes(){

        SuccesCount++;

        if (SuccesCount == sCount)
        {
            Invoke("Timeout", 2f);
            SuccessPanel.GetComponent<FoxSuccess>().Success();

        }else{
            Assets.scripts.ColibriGame.Instance.Success();
        }

    }

    void Timeout()
    {

        game1.SetActive(false);
        game2.SetActive(true);

        Assets.scripts.ColibriGame.Instance.GameVoice(6);

        SuccesCount = 0;

        if (CharsPanel != null)
        {

            foreach (Transform child in CharsPanel.transform)
            {
                child.GetComponent<Assets.scripts.FoxWordChar>().Reset();
            }

        }

    }
}
