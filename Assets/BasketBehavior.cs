using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class BasketBehavior : MonoBehaviour {

    public int SuccessCount = 0;

    //public Button ReturnBtn;

    public GameObject game1;

    public GameObject game2;

    public GameObject SuccesPanel;

    public GameObject MashroomsPanel;


    void Start(){

        //ReturnBtn.onClick.AddListener(() =>{

        //    game1.SetActive(false);
          
        //}); 

    }

    void OnTriggerEnter2D(Collider2D other){

        SuccessCount++;

        if (SuccessCount == 6){

            Invoke("Timeout", 2f);

            SuccesPanel.GetComponent<ZamSuccess>().Success();

            ColibriGame.Instance.Ewesome();

        }else{

            ColibriGame.Instance.Success();

        }

        other.gameObject.GetComponent<MashroomBehavior>().Draggable = false;

        //other.gameObject.SetActive(false);

    }

    void Timeout()
    {

        game1.SetActive(false);
        game2.SetActive(true);

        Assets.scripts.ColibriGame.Instance.GameVoice(10);

        SuccessCount = 0;

        if (MashroomsPanel != null)
        {

            foreach (Transform child in MashroomsPanel.transform)
            {
                child.GetComponent<MashroomBehavior>().Reset();
            }

        }

    }

}
