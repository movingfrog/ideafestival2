using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject quit;
    void Start()
    {
        
    }
    void Update()
    {
        
    
    }
    public void starts()
    {
        SceneManager.LoadScene("Start stage");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
