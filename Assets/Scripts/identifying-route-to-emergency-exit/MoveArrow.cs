using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float speed = 1f;
    private Vector3 startPosition;  
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
}
