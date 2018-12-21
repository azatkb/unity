using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class ThreeePanel : MonoBehaviour {

    public GameObject game0;

    public GameObject game1;

    public GameObject game2;

    public Button ReturnButton;

    public Button UnswerButton;

    public Button UnswerButton2;

    public Button UnswerButton3;

    public Button UnswerButton4;

    public GameObject SuccessPanel;

    void Start()
    {

        //ReturnButton.onClick.AddListener(() => {

        //    game0.SetActive(true);

        //    game1.SetActive(false);

        //});

        //UnswerButton.onClick.AddListener(() => {

        //    ColibriGame.Instance.Error();

        //});

        //UnswerButton2.onClick.AddListener(() => {

        //    ColibriGame.Instance.Error();

        //});

        //UnswerButton3.onClick.AddListener(() => {

        //    Invoke("Timeout", 2f);

        //    SuccessPanel.GetComponent<OftobakSuccess>().Success();

        //    ColibriGame.Instance.GreateJob();

        //});

        //UnswerButton4.onClick.AddListener(() => {

        //    ColibriGame.Instance.Error();

        //}); 

    }

    void Timeout()
    {

        game1.SetActive(false);
        game2.SetActive(true);

    }
}
