using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamSuccess : MonoBehaviour {

    public Text Successtext;

    void Start() {

        gameObject.SetActive(false);

    }

    public void Success(string text = null)
    {
        gameObject.SetActive(true);

        StartCoroutine(Timeout());

    }

    IEnumerator Timeout()
    {

        yield return new WaitForSeconds(3);

        this.gameObject.SetActive(false);

    }
}
