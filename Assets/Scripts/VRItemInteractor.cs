using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRItemInteractor : MonoBehaviour
{
    public GameObject LockObject;
    public GameObject KeyItem;

    /*private onAwake()
    {

    }*/
   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == KeyItem)
        {
           
            Destroy(LockObject);

           
            Destroy(KeyItem); 
        }
    }
}
