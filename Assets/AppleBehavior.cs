using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.scripts {

    public class AppleBehavior : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        private Vector3 originalPos;

        void Start(){

            originalPos = transform.position;

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
          
        }

        public void OnDrag(PointerEventData eventData){

            transform.position = Input.mousePosition;
                
        }

        public void OnEndDrag(PointerEventData eventData) { }

        public void OnDrop(PointerEventData eventData)
        {
            Invoke("AfterDrop", 1);
        }

        public void AfterDrop(){
           
            transform.position = originalPos;
            
        }

        public void Reset()
        {
            gameObject.SetActive(true);
            transform.position = new Vector3(originalPos.x, originalPos.y, 0);
        }

    }

}
