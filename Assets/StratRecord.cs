using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Recorder;

public class StratRecord : MonoBehaviour {

    public RecordManager recordManager;

	void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(()=>{

            recordManager.StartRecord();

        });
		
	}
	
}
