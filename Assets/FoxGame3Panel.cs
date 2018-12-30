using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class FoxGame3Panel: MonoBehaviour{

        public GameObject game0;
        public GameObject game1;
        public GameObject game2;

        public Button ReturnBtn;

        public GameObject SuccessPanel;

        public GameObject CharsPanel;

        public Sprite NormalImage;

        public GameObject WordConrinerPanel;
        public GameObject WordConrinerPanel2;
        public GameObject WordConrinerPanel3;
        public GameObject WordConrinerPanel4;

        int SuccessCount;

        void Start()
        {
            ReturnBtn.onClick.AddListener(() =>
            {

                game0.SetActive(true);

                game1.SetActive(false);


            });

        }

        public void Success() {

            SuccessCount++;

            if(SuccessCount == 4){

                Invoke("Timeout", 2f);

                SuccessPanel.GetComponent<FoxSuccess>().Success("Greate Job!");

            }
            else{

                ColibriGame.Instance.Success();

            }

        }

        void Timeout()
        {

            game1.SetActive(false);

            game2.SetActive(true);

            SuccessCount = 0;

            if (CharsPanel != null)
            {

                foreach (Transform child in CharsPanel.transform)
                {
                    child.GetComponent<Assets.scripts.FoxGame3Word>().Reset();
                }

            }

            WordConrinerPanel.GetComponent<Image>().sprite = NormalImage;
            WordConrinerPanel2.GetComponent<Image>().sprite = NormalImage;
            WordConrinerPanel3.GetComponent<Image>().sprite = NormalImage;
            WordConrinerPanel4.GetComponent<Image>().sprite = NormalImage;

        }

    }
}

