using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour {

    public GameObject mainScreeen;

    public Button mainScreeenButton;

    void Start () {

        mainScreeenButton.onClick.AddListener(()=> {
            mainScreeen.SetActive(true);
            mainScreeen.GetComponent<IntroPannel>().PlaySound();
        });

	} 
	
	// Update is called once per frame
	void Update () {
		
	}
}
