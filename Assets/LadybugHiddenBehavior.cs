using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class LadybugHiddenBehavior : MonoBehaviour {

    public Sprite NormalImage;
    public Sprite FadeImage;

    public GameObject game1;

    public GameObject game2;

    public GameObject SuccessPanel;

    void Start(){

        FadeImage = gameObject.GetComponent<Image>().sprite;

        gameObject.GetComponent<Button>().onClick.AddListener(() => {

            gameObject.GetComponent<Image>().sprite = NormalImage;

            Invoke("Timeout", 2f);

            SuccessPanel.GetComponent<OftobakSuccess>().Success();

            ColibriGame.Instance.GreateJob();

        });

    }

    void Timeout()
    {

        Assets.scripts.ColibriGame.Instance.GameVoice(19);

        game1.SetActive(false);
        game2.SetActive(true);

        gameObject.GetComponent<Image>().sprite = FadeImage;

    }


}
