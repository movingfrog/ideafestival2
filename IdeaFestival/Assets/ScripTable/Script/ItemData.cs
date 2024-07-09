using System;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    Resorce,
    Consumable
}

public enum ConsumableType
{
    Hunger,
    Health
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "Item.data", order = 1)]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject DropPrefeb;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Counsumable")]
    public ItemDataConsumable[] consumables;
}
