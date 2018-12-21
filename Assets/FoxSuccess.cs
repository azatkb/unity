using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class FoxSuccess : MonoBehaviour {

    public Text Successtext;

	void Start () {

        gameObject.SetActive(false);

	}
	
	public void Success(string text = null){

        gameObject.SetActive(true);

        ColibriGame.Instance.Ewesome();

        StartCoroutine(Timeout());

    }

    IEnumerator Timeout()
    {

        yield return new WaitForSeconds(3);

        this.gameObject.SetActive(false);

    }
}
