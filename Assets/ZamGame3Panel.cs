using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;
namespace Assets.scripts
{
    public class ZamGame3Panel: MonoBehaviour{

        public GameObject game0;
        public GameObject game1;
        public GameObject game2;
        public Button ReturnBtn;
        public GameObject SuccesPanel;
        public GameObject CharsPanel;
        public Sprite NormalImage;
        public GameObject WordConrinerPanel;
        public GameObject WordConrinerPanel2;

        int SuccessCount;

        void Start()
        {
            ReturnBtn.onClick.AddListener(() =>
            {

                game0.SetActive(true);
                game1.SetActive(false);

                Assets.scripts.ColibriGame.Instance.GameVoice(9);

            });

        }

        public void Success() {

            SuccessCount++;

            if(SuccessCount == 2){

                Invoke("Timeout", 2f);

                SuccesPanel.GetComponent<ZamSuccess>().Success();

            }

        }

        void Timeout()
        {

            game1.SetActive(false);
            game2.SetActive(true);

            Assets.scripts.ColibriGame.Instance.GameVoice(11);

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

        }

    }
}

