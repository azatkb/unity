using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoonBatton : MonoBehaviour {

    public GameObject SoonPopUp;

    public Button LevelButton;

    void Start () {

        LevelButton.onClick.AddListener(()=>
        {
            SoonPopUp.SetActive(true);
        });

    }

}
