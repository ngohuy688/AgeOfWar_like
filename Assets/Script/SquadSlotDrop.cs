using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquadSlot : MonoBehaviour, IDropHandler
{
    public Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragIcon icon = eventData.pointerDrag.GetComponent<DragIcon>();

        if (icon != null)
        {
            icon.transform.SetParent(transform);
            icon.transform.localPosition = Vector3.zero;
            img.sprite = icon.img.sprite;
        }
    }
}