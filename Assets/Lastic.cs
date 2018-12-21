﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lastic : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    public bool Draggable = true;

    private Vector3 originalPos;

    void Start()
    {

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

        if (Draggable)
        {
            transform.position = Input.mousePosition;
        }

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

}
