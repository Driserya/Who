using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class SlotUI : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Image itemImage;

    [SerializeField] private ItemDetails currentItem;

    [SerializeField] private ItemTooltip toolTip;//物品信息

    [SerializeField]private bool isSelected;//物品是否选中

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening<ItemName>("物品使用", OnItemUsedEvent);
        GameEventManager.MainInstance.AddEventListening<ItemDetails>("获取当前物品", GetCurrentItem);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent<ItemName>("物品使用", OnItemUsedEvent);
        GameEventManager.MainInstance.RemoveEvent<ItemDetails>("获取当前物品", GetCurrentItem);
    }


    private void Awake()
    {
        itemImage = GetComponent<Image>();
    }

    private void OnItemUsedEvent(ItemName itemName)
    {
        isSelected = false;
        currentItem=null;
        ChangeItem(0);
    }

    public void SetItem(ItemDetails itemDetails)
    {
        currentItem=itemDetails;
        this.gameObject.SetActive(true);
        itemImage.sprite= currentItem.itemSprite;
        itemImage.SetNativeSize();
    }

    private void GetCurrentItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
    }
    public void ChangeItem(int currentIndex)
    {
        if (this.gameObject.activeInHierarchy)
        {
            GameEventManager.MainInstance.CallEvent("获取", currentIndex);
            itemImage.sprite = currentItem.itemSprite;
            itemImage.SetNativeSize();
        }
    }

    public void SetEmpty()
    {
        this.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)//鼠标点击
    {
        isSelected = !isSelected;
        GameEventManager.MainInstance.CallEvent("拿取UI当前物品", currentItem, isSelected);
    }

    public void OnPointerEnter(PointerEventData eventData)//鼠标划入
    {
        if(this.gameObject.activeInHierarchy)
        {
            toolTip.gameObject.SetActive(true);
            toolTip.UpdateItemNamee(currentItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)//鼠标划出
    {
        toolTip.gameObject.SetActive(false);
    }
}
