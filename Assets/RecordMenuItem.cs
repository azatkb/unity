using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordMenuItem : MonoBehaviour {

    public Button ThisButton;

    public GameObject Panel;

    void Start () {

        Button btn = ThisButton.GetComponent<Button>();

        btn.onClick.AddListener(()=> {

            Panel.SetActive(true);

            Panel.GetComponent<BookRecords>().InitRows();

        });

    }

}
