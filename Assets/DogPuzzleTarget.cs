using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class DogPuzzleTarget: MonoBehaviour {

        public GameObject panel;

        //void Start()

        //}

        void OnTriggerEnter2D(Collider2D other){

            if (gameObject.tag == other.gameObject.tag)
            {

                other.gameObject.transform.position = gameObject.transform.position;

                other.gameObject.GetComponent<PuzzleItem>().Draggable = false;

                panel.GetComponent<DogPuzzleContainer>().SuccessAdd();

            }
            else
            {

                //gameObject.GetComponent<Image>().sprite = ErrorImage;

                //other.gameObject.GetComponent<WordChar>().HandleWrong();

            }

        }

    }
}

