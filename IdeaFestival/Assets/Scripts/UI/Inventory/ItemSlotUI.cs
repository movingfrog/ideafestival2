using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshPro quatityText;
    private ItemSlotUI curSlot;

    public int index;

    //������ Slot ���� ����
    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(false);
        icon.sprite = slot.item.icon;
        quatityText.text = slot.quatity > 1 ? slot.quatity :
    }

}
