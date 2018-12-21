using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetImage : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(()=> {

            //GalleryPickController.Show();
        });


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
