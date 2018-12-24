using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class PuzzleContainer: MonoBehaviour{

        public GameObject game0;
        public GameObject game1;
        public GameObject game2;

        public Button ReturnBtn;

        public GameObject SuccessPanel;

        private AudioSource Sm;

        public GameObject Puzzles;

        int SuccessCount;

        void Start(){

            Sm = gameObject.GetComponent<AudioSource>();

            if (ReturnBtn != null)
            {

                ReturnBtn.onClick.AddListener(() => {
                    game0.SetActive(true);
                    game1.SetActive(false);
                });

            }

        }

        public void SuccessAdd() {

            Sm.Play();

            SuccessCount++;

            if(SuccessCount == 6){

                Invoke("Timeout", 2f);

            }

        }

        void Timeout(){

            game2.SetActive(true);

            game1.SetActive(false);

            game2.GetComponent<FoxGame5Behavior>().Init();

            ColibriGame.Instance.Ewesome();

            SuccessPanel.GetComponent<FoxSuccess>().Success();

            SuccessCount = 0;

            if (Puzzles != null)
            {

                foreach (Transform child in Puzzles.transform)
                {
                    child.GetComponent<Assets.scripts.PuzzleItem>().Reset();
                }

            }

        }
    
    }
}

