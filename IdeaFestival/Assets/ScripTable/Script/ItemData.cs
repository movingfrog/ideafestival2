using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item.data", order = 1)]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public Sprite icon;
    public GameObject DropPrefeb;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
}
