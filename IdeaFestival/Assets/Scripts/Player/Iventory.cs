using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class ItemSlot
{
    public ItemData item;
    public int quatity;
}
public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uidSlot;
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selcteditem;
    private int selcteditemindex;
    public TextMeshPro selectedItemName;
    public TextMeshPro selectedItemDescription;
    public TextMeshPro selectedItemStatName;
    public TextMeshPro selectedItemStatValue;
    public GameObject useButton;
    public GameObject dropButton;

    public static Inventory instance;

    bool IsOnInventory = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[uidSlot.Length];

        for (int i = 0; i < uidSlot.Length; i++)
        {
            slots[i] = new ItemSlot();
            uidSlot[i].index = i;
            uidSlot[i].Clear();
        }

        
    }

    public void AddItem(ItemData item)
    {
        if (item.canStack)
        {
            //쌓일 수 있는 아이템일 경우 스택을 쌓는다
            ItemSlot slotToStackTo;//= GetItemStack(item);
        }
    }
}
