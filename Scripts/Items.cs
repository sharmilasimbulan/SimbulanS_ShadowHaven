using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Items : MonoBehaviour
{
    public GameObject KairenNaviSuccess;
    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.ItemsCollected();
            gameObject.SetActive(false);
        }

    }
}

