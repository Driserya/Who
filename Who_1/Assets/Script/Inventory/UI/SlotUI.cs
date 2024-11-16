using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] public Image itemImage;

    [SerializeField] private ItemDetails currentItem;

    private bool isSelected;

    private void Start()
    {
        itemImage = GetComponent<Image>();
    }

    public void SetItem(ItemDetails itemDetails)
    {
        currentItem=itemDetails;
        this.gameObject.SetActive(true);
        itemImage.sprite= currentItem.itemSprite;
        itemImage.SetNativeSize();
    }

    public void SetEmpty()
    {
        this.gameObject.SetActive(false);
    }

}
