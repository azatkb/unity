﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveRecordButton : MonoBehaviour {

    public GameObject Manager;

    void Start() {

        gameObject.GetComponent<Button>().onClick.AddListener(() => {

            //Manager.GetComponent<BookRecordManager>().SaveRecord();

        });

    }
}
