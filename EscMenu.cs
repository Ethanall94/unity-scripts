using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject EscMenuSet;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(EscMenuSet.activeSelf)
                EscMenuSet.SetActive(false);
            else
                EscMenuSet.SetActive(true);
        }
            
    }

    public void GameExit()
    {
        Application.Quit();
    }
}


