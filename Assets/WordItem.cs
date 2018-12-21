using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class WordItem : MonoBehaviour{

        public Sprite SuccesImage;
        public Sprite ErrorImage;
        public Sprite NormalImage;

        private bool busy = false;

        void Start()
        {
 

        }

        void OnTriggerEnter2D(Collider2D other) {

            if (gameObject.tag == other.gameObject.tag){

                if(!busy){

                    gameObject.GetComponent<Image>().sprite = SuccesImage;

                    other.gameObject.transform.position = gameObject.transform.position;

                    other.gameObject.GetComponent<WordChar>().Draggable = false;

                    gameObject.transform.parent.gameObject.GetComponent<WordBehavior>().Succes();

                    busy = true;

                }
            }
            else{

                if (!busy){

                    gameObject.GetComponent<Image>().sprite = ErrorImage;

                    ColibriGame.Instance.Error();

                }

            }

        }

        public void Reset(){

            busy = false;

            if (NormalImage)
               gameObject.GetComponent<Image>().sprite = NormalImage;

        }

    }
}

