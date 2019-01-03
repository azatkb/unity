using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

    public GameObject choosePanel;

    void Start() {

        StartCoroutine(Timeout());

    }

    IEnumerator Timeout(){

        yield return new WaitForSeconds(1);

        choosePanel.SetActive(true);

    }

}
