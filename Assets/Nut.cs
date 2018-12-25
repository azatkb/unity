using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Nut : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    private Vector3 originalPos;

    void Start() {

        

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData){

        transform.position = Input.mousePosition;
     

    }

    public void OnEndDrag(PointerEventData eventData) { }

    public void OnDrop(PointerEventData eventData)
    {
        Invoke("AfterDrop", 1);
    }

    public void AfterDrop()
    {
       
        transform.position = originalPos;
        
    }

    public void Reset()
    {

        transform.position = new Vector3(originalPos.x, originalPos.y, 0);

        gameObject.SetActive(true);

    }

}
