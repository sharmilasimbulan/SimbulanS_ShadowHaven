using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class ItemUI : MonoBehaviour
{
    private TextMeshProUGUI Itemcount;

    private void Start()
    {
        Itemcount = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateItemcount(Inventory inventory)
    {
        Itemcount.text = inventory.NumberOfItems.ToString();
        
    }
}
