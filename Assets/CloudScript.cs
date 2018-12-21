using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

	void Start () {
        gameObject.SetActive(false);
	}

    public  void Forbidden(){
        gameObject.SetActive(true);
        StartCoroutine(Timeout());
    }

    IEnumerator Timeout(){
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

}
