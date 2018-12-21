using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class ZamGame3WordContainer : MonoBehaviour{

        public GameObject panel;

        public Sprite SuccessImage;

        void Start(){

              
 
        }

        void OnTriggerEnter2D(Collider2D other) {

            if (gameObject.tag == other.gameObject.tag){

                panel.gameObject.GetComponent<ZamGame3Panel>().Success();

                other.GetComponent<FoxGame3Word>().Draggable = false;

                other.gameObject.transform.position = gameObject.transform.position;

                gameObject.GetComponent<Image>().sprite = SuccessImage;

                ColibriGame.Instance.Success();

            }
            else{

                ColibriGame.Instance.Error();

            }

        }
    
    }
}

