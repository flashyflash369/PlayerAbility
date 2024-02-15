using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Collectable/Items")]
public class ScriptableItem : ScriptableObject
{

    public string itemName;
    [TextArea()]
    public string itemDescription;
    public Sprite itemImage;
}
