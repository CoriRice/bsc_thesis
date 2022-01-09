using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider HungerSlider;

    public static float hunger;
    public static float val;
    private float maxHunger = 45;
    [SerializeField] private float foodValue;
    
    // Start is called before the first frame update
    void Start()
    {
        hunger = maxHunger;
        val = foodValue;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hunger: " + hunger);
        HungerSlider.value = hunger;
        
        if (hunger >= 0) hunger -= 0.3f * Time.deltaTime;
        
    }
}
