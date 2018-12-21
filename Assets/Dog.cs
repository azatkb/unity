using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class Dog : MonoBehaviour {

    int SuccessCount = 0;

    public GameObject game1;

    public GameObject game2;

    public GameObject SuccessPanel;

    public GameObject DogPanel;

    public GameObject Trapka; 

    void Update () {

	}

    public void Success(){

        SuccessCount++;

        if (SuccessCount == 5){


            SuccessPanel.GetComponent<DogSuccess>().Success();

            ColibriGame.Instance.GreateJob();

            Invoke("Timeout", 3f);

        }

    }

    void Timeout(){


        SuccessCount = 0;

        Trapka.GetComponent<Trapka>().AfterDrop();

        //if (DogPanel != null){

            foreach (Transform child in transform) {
               child.GetComponent<GrazTarget>().Reset();
            }

        //}

        game1.SetActive(false);
        game2.SetActive(true);


    }


}
