using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogSleepButton : MonoBehaviour {


    public GameObject Cloud;

    public Button SleepButton;

    void Start()
    {

        Cloud.SetActive(false);

        SleepButton.onClick.AddListener(() =>
        {
            Cloud.SetActive(true);
            StartCoroutine(Timeout());
        });

    }

    IEnumerator Timeout(){

        yield return new WaitForSeconds(3);
        Cloud.SetActive(false);


    }
}
