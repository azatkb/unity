using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Assets.scripts {

    public class WordChar : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {

        public bool Draggable = true;

        public Vector3 originalPos = new Vector3(0, 0, 0);

        void Start(){

            InvokeRepeating("SetPosition", 1, 1f);

        }

        void SetPosition(){

            if((transform.position.x != 0) && (transform.position.y != 0)){

                originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
      
                CancelInvoke("SetPosition");

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
                transform.position = originalPos;
            }
        }

        public void Reset(){


            Draggable = true;

            transform.position = originalPos;


        }

    }

}
