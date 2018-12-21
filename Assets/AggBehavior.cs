using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AggBehavior : MonoBehaviour {

    public GameObject panel;

    public Sprite NormalImage;

    public Sprite ShowImage;

    void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(() => {

            gameObject.GetComponent<Image>().sprite = ShowImage;

            panel.GetComponent<AggWrapper>().Success();

            Assets.scripts.ColibriGame.Instance.Ewesome();


        });

        //StartCoroutine(ShowInterval());\

        //StartTimeout();

    }

    //public void StartTimeout(){

    //    gameObject.GetComponent<Image>().sprite = ShowImage;

    //    Invoke("Timeout", 5f);

    //}

    //void Timeout(){
    //    Debug.Log("Normal Image");
    //    gameObject.GetComponent<Image>().sprite = NormalImage;

    //}

}
