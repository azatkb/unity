using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StratScene : MonoBehaviour {


	void Start () {

        StartCoroutine(Timeout());

    }

    IEnumerator Timeout()
    {

        yield return new WaitForSeconds(3);

        SceneManager.LoadSceneAsync("Main");


    }


}
