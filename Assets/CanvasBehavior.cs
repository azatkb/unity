using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehavior : MonoBehaviour {


    public GameObject can1;
    public GameObject can2;
    public GameObject can3;

    // Use this for initialization
    void Start () {

        can1.SetActive(false);
        can2.SetActive(false);
        can3.SetActive(false);

        Application.runInBackground = true;

        gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();

        //foreach (Transform child in transform)
        //{
        //    child.position = transform.position;
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
