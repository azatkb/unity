using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Kakera
{
    public class PickerController : MonoBehaviour
    {
        [SerializeField]
        private Unimgpicker imagePicker;

        public RawImage image;

        public GameObject profilePanel;

        void Start(){

            gameObject.GetComponent<Button>().onClick.AddListener(()=> {

                OnPressShowPicker();

            });

        }

        void Awake()
        {
            imagePicker.Completed += (string path) =>
            {
                //Debug.Log(path);
                StartCoroutine(LoadImage(path));
            };

            imagePicker.Failed += (string messages) => {

                Debug.LogError(messages);
            
            };
        }

        public void OnPressShowPicker()
        {
            imagePicker.Show("Select Image", "unimgpicker", 700);
        }

        private IEnumerator LoadImage(string path)
        {
            var url = "file://" + path;

            var www = new WWW(url);

            yield return www;

            try{

                var texture = www.texture;

                if (texture != null)
                {

                    image.texture = www.texture;
                    profilePanel.GetComponent<ProfilePanel>().CurrentUserPhoto.texture = www.texture;
                    profilePanel.GetComponent<ProfilePanel>().AddphotoTexture = www.texture;

                }

            }
            catch{

            }




        }
    }
}