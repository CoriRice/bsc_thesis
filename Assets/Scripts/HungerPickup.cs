using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerPickup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HungerBar.hunger = HungerBar.hunger >= 100 ? 100 : HungerBar.hunger + HungerBar.val;
            Destroy(gameObject);
        }
    }
}
