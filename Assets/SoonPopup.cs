using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoonPopup : MonoBehaviour {

    public Button OKButton;

    public Button CloseButton;

    void Start () {

        gameObject.SetActive(false);

        OKButton.onClick.AddListener(() => {

            gameObject.SetActive(false);

        });

        CloseButton.onClick.AddListener(() => {

            gameObject.SetActive(false);

        });

    }
	
}
