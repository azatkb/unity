using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : MonoBehaviour
{

    public GameObject Panel;

    public Button CloseButton;

    public Button OkButton;

    public Button CancelButton;

    void Start()
    {

        Panel.SetActive(false);

        Button btn = CloseButton.GetComponent<Button>();

        btn.onClick.AddListener(() => {

            this.Panel.SetActive(false);

        });

        //CancelButton.onClick.AddListener(() => {

        //    this.Panel.SetActive(false);

        //});

        //OkButton.onClick.AddListener(() => {

        //    Application.Quit();

        //});

    }

}
