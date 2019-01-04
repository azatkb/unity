using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class DogPuzzleContainer: MonoBehaviour{

        public GameObject game0;
        public GameObject game1;
        public GameObject game2;
        public GameObject aggWrapper;

        public GameObject Puzzles;

        public Button ReturnBtn;

        public GameObject SuccessPanel;

        private AudioSource Sm;

        int SuccessCount;

        void Start()
        {

            Sm = gameObject.GetComponent<AudioSource>();

            ReturnBtn.onClick.AddListener(() =>
            {

                game0.SetActive(true);
                game1.SetActive(false);

                Assets.scripts.ColibriGame.Instance.GameVoice(16);

            });

        }

        public void SuccessAdd() {

            Sm.Play();

            SuccessCount++;

            if(SuccessCount == 6){

                Invoke("Timeout", 2f);

                ColibriGame.Instance.Ewesome();

                aggWrapper.GetComponent<AggWrapper>().InitImages();

                SuccessPanel.GetComponent<DogSuccess>().Success();

            }

        }

        void Timeout(){

            game2.SetActive(true);

            game1.SetActive(false);

            Assets.scripts.ColibriGame.Instance.GameVoice(17);

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

