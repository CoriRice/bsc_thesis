using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("UIManager is null");
            return _instance;
        } 
    }

    public Text collectibleText;
    
    void Awake()
    {
        _instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinText(int coins)
    {
        collectibleText.text = coins + " / 5";
    }
}
