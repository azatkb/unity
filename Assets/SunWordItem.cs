using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class SunWordItem : MonoBehaviour{

        public GameObject panel;

        public Sprite SuccesImage;
        public Sprite ErrorImage;
        public Sprite NormalImage;

        void Start()
        {
 

        }

        void OnTriggerEnter2D(Collider2D other) {

            if (gameObject.tag != null && gameObject.tag == other.gameObject.tag)
            {

                gameObject.GetComponent<Image>().sprite = SuccesImage;

                other.gameObject.transform.position = gameObject.transform.position;

                other.gameObject.GetComponent<WordChar>().Draggable = false;

                panel.GetComponent<SunPanel>().Success();

            }
            else{

                gameObject.GetComponent<Image>().sprite = ErrorImage;

                ColibriGame.Instance.Error();

            }

        }

        public void Reset()
        {

            gameObject.GetComponent<Image>().sprite = NormalImage;

        }

    }

}

