using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FoxGame5Behavior : MonoBehaviour {

    public GameObject SuccessPanel;
    public GameObject MianScreen;
    public GameObject FoxScreen;
    public GameObject ProfileScreen;
    public GameObject Game1;
    public GameObject Canvas;

    public GameObject can1;
    public GameObject can2;
    public GameObject can3;

    public Button CloseFox;

    public GameObject CloseElephant;

    void Start () {

        gameObject.SetActive(false);

        CloseElephant.SetActive(false);

        CloseFox.onClick.AddListener(() =>
        {

            Disable();

            SuccessPanel.GetComponent<FoxSuccess>().Success();

            StartCoroutine(Timeout());

            string Id = PlayerPrefs.GetString("CurrentUser");

            if (Id.Length == 0)
            {

                int level = PlayerPrefs.GetInt("Level");


                if (level < 2)
                {

                    PlayerPrefs.SetInt("Level", 2);

                    PlayerPrefs.Save();

                }

            }
            else
            {

                ProfileScreen.GetComponent<ProfilePanel>().SetLevel(Id, 2);

            }

        });


    }

    IEnumerator Timeout() {

        yield return new WaitForSeconds(3);

        FoxScreen.SetActive(false);

        gameObject.SetActive(false);

        Game1.SetActive(true);

        MianScreen.GetComponent<MainScreen>().State();

        MianScreen.GetComponent<MainScreen>().OpenFeeding(2);

    }

    public void Init()
    {

        StartCoroutine(InitDrawble());

    }


    IEnumerator InitDrawble()
    {

        yield return new WaitForSeconds(3f);

        Canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

        CloseFox.gameObject.SetActive(true);

        can1.SetActive(true);

        can2.SetActive(true);

        can3.SetActive(true);

        can1.GetComponent<IndieStudio.DrawingAndColoring.Logic.GameManager>().LoadInimal(5);

    }

    public void Disable()
    {

        can1.SetActive(false);

        can2.SetActive(false);

        can3.SetActive(false);

        Canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        //can3.GetComponent<IndieStudio.DrawingAndColoring.Logic.ShapesCanvas>().CleanShapes();


    }

}
