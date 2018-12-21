using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwlBehavior: MonoBehaviour {

    public Button ThisButton;

    public GameObject Panel;

    void Start () {

        Button btn = ThisButton.GetComponent<Button>();

        btn.onClick.AddListener(()=> {

            this.Panel.SetActive(true);

            Panel.GetComponent<SayPanel>().PlaySound();

        });

    }

}
