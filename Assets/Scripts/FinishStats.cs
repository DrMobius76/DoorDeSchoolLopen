using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStats : MonoBehaviour
{
    public Menu menu;

    public GameObject startButton;


    // Update is called once per frame
    void Update()
    {
        if(Ready()) startButton.SetActive(true);
    }

    public bool Ready()
    {
        if (menu.timeLimit != 0) return true;
        else return false;
    }
}
