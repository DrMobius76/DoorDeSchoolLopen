using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertaris : MonoBehaviour
{
    public bool hasRedKey;
    public bool hasBlueKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetRedKey(bool value)
    {
        hasRedKey = value;
    }

    public void SetBlueKey(bool value)
    {
        hasBlueKey = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
