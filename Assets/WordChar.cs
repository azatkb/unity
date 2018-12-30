using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Assets.scripts {

    public class WordChar : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {

        public bool Draggable = true;

        private Vector3 originalPos;

        void Start(){

            Invoke("SetPosition", 3);

        }

        void SetPosition(){

            Debug.Log(originalPos.x);
            Debug.Log(originalPos.y);
            Debug.Log(originalPos.z);

            originalPos = transform.position;

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

           

            Draggable = true;

            transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);

            gameObject.SetActive(true);


        }

    }

}
