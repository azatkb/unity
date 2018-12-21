using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class FoxWordItem : MonoBehaviour{

       

        void Start()
        {
 

        }

        void OnTriggerEnter2D(Collider2D other) {

            if (gameObject.tag == other.gameObject.tag){

                other.gameObject.transform.position = gameObject.transform.position;

                other.gameObject.GetComponent<WordChar>().Draggable = false;

                gameObject.transform.parent.gameObject.GetComponent<FoxWordBehavior>().Succes();

            }
            else{

                ColibriGame.Instance.Error();

            }

        }

    
    }
}

