using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryObjectInterface : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Text quantity;
    public Image sprite;
    public Button button;
    public int id;
    public Text NameSlot;

    public InventoryManager manager;

    public static InventoryObjectInterface moveObject;

    public void OnBeginDrag(PointerEventData eventData)
    {
        moveObject = this;
        InventoryObjectPH.current.sprite.sprite = sprite.sprite;

    }
    public void OnDrag(PointerEventData eventData)
    {
        InventoryObjectPH.current.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        moveObject = null;

        InventoryObjectPH.current.transform.position = new Vector3(10000, 1000, 100);
    }

    public void OnDrop(PointerEventData data)
    {
        
        if (moveObject == null)
            return;
        if (moveObject == this)
            return;
       manager.ExchangePositions(id, moveObject.id);
      
    }
    
}
