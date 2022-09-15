using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Itens;

public class ItemCollactableCoin : ItemCollactableBase
{    
    public Collider2D collider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);
        collider.enabled = false;
    }
}
