using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class ThreeBottom : MonoBehaviour {

    int CurrentStep = 0;

    public Image Step1Image;

    public Image Step2Image;

    public Image Step3Image;

    public Image Step4Image;

    public Image Step5Image;

    public Sprite NormalImage;

    public Sprite SuccessImage;

    public GameObject SuccessPanel;

    public GameObject OftobakGame;

    public GameObject MainScreen;

    public GameObject ProfileScreen;

    public GameObject Game1;
    public GameObject Game5;

    public GameObject BuscketOb;

    private Image[] StepImages = new Image[] { };

    void Start(){

        StepImages = new Image[] { Step1Image , Step2Image, Step3Image, Step4Image , Step5Image };

        InitStep();

    }

    int EnterCount = 0;

    void OnTriggerEnter2D(Collider2D other){

        other.gameObject.GetComponent<Image>().sprite = SuccessImage;

        EnterCount++;

        if(EnterCount == 3){

            EnterCount = 0;

            CurrentStep++;

            InitStep();

            ColibriGame.Instance.Ewesome();

        }

    }

    void InitStep(){

         for(int i = 0; i < StepImages.Length; i++){

             if(i == CurrentStep){

                StepImages[i].gameObject.SetActive(true);

             }else{

                if (CurrentStep == 4){

                    SuccessPanel.GetComponent<OftobakSuccess>().Success();

                    StartCoroutine(Timeout());

                }
                else{

                    StepImages[i].gameObject.SetActive(false);

                }
            }
         }

    }

    IEnumerator Timeout(){

        string Id = PlayerPrefs.GetString("CurrentUser");

        if (Id.Length == 0){

            PlayerPrefs.SetInt("Level", 5);

            PlayerPrefs.Save();

        }
        else {

            ProfileScreen.GetComponent<ProfilePanel>().SetLevel(Id, 5);

        }

        yield return new WaitForSeconds(3);

        this.BuscketOb.GetComponent<Buscket>().AfterDrop();

        CurrentStep = 0;

        EnterCount = 0;

        InitStep();

        OftobakGame.SetActive(false);

        Game5.SetActive(false);

        Game1.SetActive(true);

        MainScreen.GetComponent<MainScreen>().State();

    }

}
   