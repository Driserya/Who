using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI itemNameText;

    public void UpdateItemNamee(ItemDetails itemDetails) => UpdateItemName(itemDetails);


    private void UpdateItemName(ItemDetails itemDetails)
    {
        itemNameText.text= itemDetails.chineseNmae;
    }
}
