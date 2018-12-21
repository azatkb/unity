using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class AggWrapper : MonoBehaviour {

    public GameObject game0;

    public GameObject game1;

    public GameObject SuccessPanel;

    public GameObject MianScreen;

    public GameObject GameScreen;

    //public Button ReturnButton;

    public GameObject ProfileScreen;

    public Image Agg1;

    public Image Agg2;

    public Image Agg3;

    public Sprite NormalImage;

    public Sprite ShowImage;

    public GameObject Game1;

    public GameObject Game5;


    int SuccessCount = 0;

    void Start () {

        //ReturnButton.onClick.AddListener(() => {

        //    game0.SetActive(true);

        //    game1.SetActive(false);

        //});

    }

    public void Success(){

        SuccessCount++;

        if(SuccessCount == 3){

            ColibriGame.Instance.GreateJob();


            Invoke("Timeout", 3.5f);

            string Id = PlayerPrefs.GetString("CurrentUser");

            if (Id.Length == 0){

                int level = PlayerPrefs.GetInt("Level");

                if (level < 4)
                {
                    PlayerPrefs.SetInt("Level", 4);

                    PlayerPrefs.Save();

                }

            }
            else {

                ProfileScreen.GetComponent<ProfilePanel>().SetLevel(Id, 4);

            }

            SuccessPanel.GetComponent<DogSuccess>().Success();



        }

    }

    void Timeout() {

        GameScreen.SetActive(false);

        Game5.SetActive(false);

        Game1.SetActive(true);

        SuccessCount = 0;

        MianScreen.GetComponent<MainScreen>().State();

        MianScreen.GetComponent<MainScreen>().OpenFeeding(4);

    }

    public void  InitImages(){

        Agg1.sprite = ShowImage;

        Agg2.sprite = ShowImage;

        Agg3.sprite = ShowImage;

        Invoke("ChangeImage", 4f);


    }


    void ChangeImage(){

        Agg1.sprite = NormalImage;

        Agg2.sprite = NormalImage;

        Agg3.sprite = NormalImage;

    }


}
