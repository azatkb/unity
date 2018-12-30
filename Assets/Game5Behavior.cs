using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game5Behavior : MonoBehaviour {
 
    public Button CloseElephant;
    public Button CloseFox;
    public GameObject SuccessPanel;
    public GameObject ElephantGame;
    public GameObject MianScreen;
    public GameObject ProfileScreen;
    public GameObject Game1;
    public GameObject Canvas;
    public GameObject can1;
    public GameObject can2;
    public GameObject can3;

    void Start () {

        gameObject.SetActive(false);

        CloseElephant.onClick.AddListener(() =>
        {

            StartCoroutine(Timeout());

            Disable();

            SuccessPanel.GetComponent<ElephantSuccess>().Success();


            string Id = PlayerPrefs.GetString("CurrentUser");

            if (Id.Length == 0)
            {

                int level = PlayerPrefs.GetInt("Level");

                if (level < 1)
                {

                    PlayerPrefs.SetInt("Level", 1);

                    PlayerPrefs.Save();

                }

            }
            else
            {

                ProfileScreen.GetComponent<ProfilePanel>().SetLevel(Id, 1);

            }

        });


    }

    IEnumerator Timeout() {

        yield return new WaitForSeconds(3.5f);

        gameObject.SetActive(false);

        Game1.SetActive(true);

        ElephantGame.SetActive(false);

        Assets.scripts.ColibriGame.Instance.RecoverMusic();

        MianScreen.GetComponent<MainScreen>().State();

        MianScreen.GetComponent<MainScreen>().OpenFeeding(1);

    }

    public void Init(){

        StartCoroutine(InitDrawble());

    }

    IEnumerator InitDrawble(){

        yield return new WaitForSeconds(1f);

        CloseFox.gameObject.SetActive(false);

        CloseElephant.gameObject.SetActive(true);

        Canvas.SetActive(true);

        can1.SetActive(true);

        can2.SetActive(true);

        can3.SetActive(true);

        can1.GetComponent<IndieStudio.DrawingAndColoring.Logic.GameManager>().LoadInimal();

        Canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

    }


    public void Disable(){

        can1.GetComponent<IndieStudio.DrawingAndColoring.Logic.GameManager>().CleanCurrentShapeScreen();

        can1.SetActive(false);

        can2.SetActive(false);

        can3.SetActive(false);

        Canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

    }

}
