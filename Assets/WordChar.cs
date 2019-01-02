using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Assets.scripts {

    public class WordChar : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {

        public bool Draggable = true;

        private Vector3 originalPos = new Vector3(0, 0, 0);

        void Start(){

            originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            //Invoke("SetPosition", 3);

        }

        void SetPosition(){

            if(originalPos.x == 0){

                originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); 

            }

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
       
        }

        public void OnDrag(PointerEventData eventData){

           if(Draggable){
                transform.position = Input.mousePosition;
           }
         
        }

        public void OnEndDrag(PointerEventData eventData){}

        public void OnDrop(PointerEventData eventData) {
            Invoke("AfterDrop", 1);
        }
         
        public void AfterDrop(){

            if (Draggable){
                transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
            }
        }

        public void Reset(){


            Debug.Log(gameObject.name);
            Debug.Log(transform.position.x);

            Draggable = true;

            transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);

            gameObject.SetActive(true);


        }

    }

}
