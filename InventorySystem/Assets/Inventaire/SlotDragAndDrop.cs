using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Inventory inventory;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    [SerializeField] private Vector2 orinalPostion;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        inventory = GetComponentInParent<Inventory>();
        orinalPostion = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        orinalPostion = rectTransform.anchoredPosition;
        Debug.Log($"alros vous etes en {orinalPostion} + {name}");
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        canvasGroup.blocksRaycasts = false;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerEnter == null || eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<SlotDragAndDrop>() == null)
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = orinalPostion;

        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Name : "+name);
        // Je drag sur celui que je pointe 
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            GetComponent<RectTransform>().anchoredPosition;

        Debug.Log($"{orinalPostion} alros vous etes en {GetComponent<SlotDragAndDrop>().name} et { eventData.pointerDrag.GetComponent<RectTransform>().name}");
        
        GetComponent<SlotDragAndDrop>().SetOrinalPostion(eventData.pointerDrag.GetComponent<SlotDragAndDrop>().GetOrinalPostion());
    }

    public void SetOrinalPostion(Vector2 _newPostion)
    {
        orinalPostion = _newPostion;
        rectTransform.anchoredPosition = orinalPostion;
    }
    
    public Vector2 GetOrinalPostion()
    {
        return orinalPostion;
    }
}
