using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogSuccess : MonoBehaviour {

    public Text Successtext;

	void Start () {

        gameObject.SetActive(false);

	}
	
	public void Success(string text = null){

        Assets.scripts.ColibriGame.Instance.GreateJob();

        gameObject.SetActive(true);

        StartCoroutine(Timeout());

    }

    IEnumerator Timeout()
    {

        yield return new WaitForSeconds(2.5f);

        this.gameObject.SetActive(false);

    }
}
