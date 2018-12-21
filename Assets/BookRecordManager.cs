using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;

public class BookRecordManager : MonoBehaviour {

    public RecordManager recordManager;

	public void SratRecord(){

        Debug.Log("Record start");

        recordManager.StartRecord();

    }

    public void SaveRecord(){

        Debug.Log("Saving");

        recordManager.StopRecord();

    }

}
