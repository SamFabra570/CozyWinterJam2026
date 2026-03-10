using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextOptionSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] public int slotNumber = 0;
    [SerializeField] public TextMeshProUGUI text;
    
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("cmon man im tryna drop here");
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            text= draggableItem.text;
            
            JournalManager.Instance.ShowTexts(draggableItem.text.text, draggableItem.gameObject);
            Debug.Log("Called show texts");
        }
    }
}
