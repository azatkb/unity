using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
using Assets.scripts;

public class ZamCharConteiner : MonoBehaviour
{

    public GameObject panel;

    public Sprite SuccessImage;

    public Sprite ErrorImage;

    public Sprite NormalImage;

    void Start(){

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject.tag == other.gameObject.tag){

            other.gameObject.transform.position = gameObject.transform.position;

            gameObject.GetComponent<Image>().sprite = SuccessImage;

            other.gameObject.GetComponent<ZamGame3Char>().Draggable = false;

            panel.gameObject.GetComponent<ZamCharWrapperConteianer>().Success();

            ColibriGame.Instance.Success();

        }
        else {

            gameObject.GetComponent<Image>().sprite = ErrorImage;

            ColibriGame.Instance.Error();

        }

    }

    public void Reset(){

        gameObject.GetComponent<Image>().sprite = NormalImage;

    }
}
