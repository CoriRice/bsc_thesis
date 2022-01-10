using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int changeTo;

    /*private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(changeTo);
    }*/

    public void LoadScene()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene(changeTo);
    }
}