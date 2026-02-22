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
            PlayerController.Instance.TextManager.GenerateText();


        }
    }
}
