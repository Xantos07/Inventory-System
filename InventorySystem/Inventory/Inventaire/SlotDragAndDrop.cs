using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDragAndDrop : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler
{
    private DragAndDropManager dragAndDropManager;
    //
    private InventoryItem inventoryItem;
    private CraftSlotItem craftSlotItem;
    //
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 orinalPostion;
    private bool isDragging = true;
    private IDragHandler _dragHandlerImplementation;

    private void Start()
    {
        dragAndDropManager = GetComponentInParent<DragAndDropManager>();
        //
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //
        inventoryItem = GetComponent<InventoryItem>();
        craftSlotItem = GetComponent<CraftSlotItem>();
    }

    
    public void ResetPosition()
    {
        isDragging = !isDragging;
        canvasGroup.blocksRaycasts = isDragging;
        
        GetComponent<RectTransform>().anchoredPosition = orinalPostion;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (dragAndDropManager.GetSlot() != null)
        {
            dragAndDropManager.AddToSlot(inventoryItem);
            return;
        }

        if (inventoryItem.GetItem()==null)
        {
            return;
        }
        

        dragAndDropManager.SetSlot(this, inventoryItem);
        
        orinalPostion = rectTransform.anchoredPosition;

        isDragging = !isDragging;
        canvasGroup.blocksRaycasts = isDragging;

    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryItem mySlot = eventData.pointerEnter.GetComponent<InventoryItem>();

        if (mySlot == null)
        {
            return;
        }
        
       // Debug.Log(mySlot.name);
        dragAndDropManager.SetDivisionCount(mySlot);
    }
}
