using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehavior : MonoBehaviour {

    public GameObject can1;
    public GameObject can2;
    public GameObject can3;

    void Start () {

        can1.SetActive(false);
        can2.SetActive(false);
        can3.SetActive(false);

        Application.runInBackground = true;

        foreach (Transform child in transform)
        {
            child.transform.position = transform.position;
        }


    }

	void Update () {
		
	}
}
