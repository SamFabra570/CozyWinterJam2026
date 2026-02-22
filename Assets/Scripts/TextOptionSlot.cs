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
            
            if (slotNumber == 1)
            {
                PlayerController.Instance.TextManager.Word1 = text.text;
            }
            else if (slotNumber == 2)
            {
                PlayerController.Instance.TextManager.Word2 = text.text;
            }
            else if (slotNumber == 3)
            {
                PlayerController.Instance.TextManager.Word3 = text.text;
            }
            else if (slotNumber == 4)
            {
                PlayerController.Instance.TextManager.Word4 = text.text;
            }
            else if (slotNumber == 5)
            {
                PlayerController.Instance.TextManager.Word5 = text.text;
            }
            else if (slotNumber == 6)
            {
                PlayerController.Instance.TextManager.Word6 = text.text;
            }
            else if (slotNumber == 7)
            {
                PlayerController.Instance.TextManager.Word7 = text.text;
            }
            else if (slotNumber == 8)
            {
                PlayerController.Instance.TextManager.Word8 = text.text;
            }
            else if (slotNumber == 9)
            {
                PlayerController.Instance.TextManager.Word9 = text.text;
            }
            


        }
    }
}
