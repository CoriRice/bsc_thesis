using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private String changeTo;

    /*private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(changeTo);
    }*/

    public void LoadScene()
    {
        SceneManager.LoadScene(changeTo);
    }

    public void OnEnable()
    {
        LoadScene();
    }
}