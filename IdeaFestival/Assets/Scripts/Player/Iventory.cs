using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (item.canStack)
        {
            //쌓일 수 있는 아이템일 경우 스택을 쌓는다
            ItemSlot slotToStackTo = GetItemStack(item);

            if(slotToStackTo != null)
            {
                slotToStackTo.quatity++;
                UpdateUI();
                return;
            }
        }

        //없을 경우 빈칸에 아이템을 추가
        ItemSlot emptySlot = GetEmptySlot();


        if(emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quatity = 1;
            UpdateUI();
            return;
        }

        //인벤토리에 빈칸이 없을 경우
        ThrowItem(item);
    }

    private void ThrowItem(ItemData item)
    {
        Instantiate(item.DropPrefeb, dropPosition.position, Quaternion.Euler(Vector3.zero));
    }

    void UpdateUI()
    {
        //slot에 있는 아이템 데이터 최신화 하기
        for(int i =0;i<slots.Count();i++)
        {
            if (slots[i].item != null)
            {
                uidSlot[i].Set(slots[i]);
            }
            else
                uidSlot[i].Clear();
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for(int i = 0;i<slots.Length;i++)
        {
            if (slots[i].item == item && slots[i].quatity < item.maxStackAmount)
            {
                return slots[i];
            }
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }
        return null;
    }

    public void SelectItem(int index)
    {
        if (slots[index].item != null)
        {
            return;
        }

        selecteditem = slots[index];
        selecteditemindex = index;

        selectedItemName.text = selecteditem.item.displayName;
        selectedItemDescription.text = selecteditem.item.description;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        for(int i = 0; i < selecteditem.item.consumables.Length; i++)
        {
            selectedItemStatName.text += selecteditem.item.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selecteditem.item.consumables[i].value.ToString() + "\n";
        }

        useButton.SetActive(selecteditem.item.type == ItemType.Consumable);
        dropButton.SetActive(true);
    }

    private void ClearSelectItemWindow()
    {
        selecteditem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text= string.Empty;
        selectedItemStatValue.text= string.Empty;
    }

    public void OnUseButton()
    {
        if(selecteditem.item.type == ItemType.Consumable)
            for(int i = 0;i<selecteditem.item.consumables.Length;i++)
            {
                switch (selecteditem.item.consumables[i].type)
                {
                    case ConsumableType.Hunger:
                        break;
                }
            }
        RemoveSelectedItem();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (IsOnInventory)
            {
                IsOnInventory = true;
                Time.timeScale = 0.0f;
                inventoryWindow.SetActive(true);
            }
            else
            {
                IsOnInventory = false;
                Time.timeScale = 1.0f;
                inventoryWindow.SetActive(false);
            }
        }
    }

    public void OnDropButton()
    {
        ThrowItem(selecteditem.item);
        RemoveSelectedItem();
    }

    private void RemoveSelectedItem()
    {
        selecteditem.quatity--;

        if(selecteditem.quatity <= 0)
        {
            selecteditem.item = null;
            ClearSelectItemWindow();
        }
        UpdateUI();
    }

    public bool HasItem(ItemData item, int index)
    {
        return false;
    }
}
