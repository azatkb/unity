using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts
{
    public class ElephantMouht : MonoBehaviour{

        private int SuucessCount = 0;
        public GameObject game0;
        public GameObject game1;
        public GameObject game2;
        //public Button ReturnButton;
        public GameObject SuccessPanel;

        public GameObject ApplesPanel;

        private AudioSource sm;

        void Start() {

            sm = gameObject.GetComponent<AudioSource>();

            //ReturnButton.onClick.AddListener(() => {

            //    game1.SetActive(false);
            //    game0.SetActive(true);

            //});

        }

        void OnTriggerEnter2D(Collider2D other) {

            other.gameObject.SetActive(false);

            sm.Play();

            SuucessCount++;

            if(SuucessCount == 6){

                SuccessPanel.GetComponent<ElephantSuccess>().Success("GREATE JOB!");

                Invoke("Timeout", 2f);
            }
            else{
                //ColibriGame.Instance.Success();
            }

        }

        void Timeout()
        {

            game1.SetActive(false);
            game2.SetActive(true);

            SuucessCount = 0;

            if (ApplesPanel != null)
            {
                foreach (Transform child in ApplesPanel.transform)
                {
                    child.GetComponent<Assets.scripts.AppleBehavior>().Reset();
                }

            }

        }

    }
}

