using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider hungerSlider;
    public static float hunger;
    public static float val;
    float maxHunger = 33f;
    [SerializeField] private float foodValue;

    // Start is called before the first frame update
    void Start()
    {
        hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        val = foodValue;
        Debug.Log("Hunger: " + hunger);
        hungerSlider.value = hunger;
        
        if (hunger >= 0) hunger -= 0.3f * Time.deltaTime;
    }
}
