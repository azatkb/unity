using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour {

    public GameObject Screen;

	void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(()=> {

            PlayerPrefs.DeleteAll();
            Screen.GetComponent<MainScreen>().State();

        });
		
	}
	
}
