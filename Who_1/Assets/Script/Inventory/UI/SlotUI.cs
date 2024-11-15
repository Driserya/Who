using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    [SerializeField] private ItemDetails currentItem;

    private bool isSelected;

    public void SetItem(ItemDetails itemDetails)
    {
        currentItem=itemDetails;
        this.gameObject.SetActive(true);
        itemImage.sprite= currentItem.itemSprite;
        itemImage.SetNativeSize();
    }

    public void SetEmoty()
    {
        this.gameObject.SetActive(false);
    }

}
