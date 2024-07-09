using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshPro quatityText;
    private ItemSlot curSlot;

    public int index;

    //아이템 Slot 정보 전달
    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(false);
        icon.sprite = slot.item.icon;
        quatityText.text = slot.quatity > 1 ? slot.quatity.ToString() : string.Empty;
    }

    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
        quatityText.text = string.Empty;
    }

    public void OnButtonClick()
    {
        Inventory.instance.SelectItem(index);
    }
}
