using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToetsenScherm : MonoBehaviour
{
    public GameObject Player;
    public float distance;

    public GameObject numberPad;
    // Start is called before the first frame update

    public void ScreenActive()
    {
        if (distance < 5 /*&& gotKeyCard*/)
        {
            numberPad.SetActive( true );
        }
    }
    void Start()
    {
        distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
