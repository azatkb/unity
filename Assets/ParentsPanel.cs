using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentsPanel : MonoBehaviour {

    public GameObject Panel;

    public Button CloseButton;

    void  Start(){

        Panel.SetActive(false);

        Button btn = CloseButton.GetComponent<Button>();

        btn.onClick.AddListener(() => {

            this.Panel.SetActive(false);

        });

    }

}
