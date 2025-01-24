using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = this.gameObject;
        GameManager.Instance.optiesMenu = gameObject;
        Debug.Log(GameManager.Instance.optiesMenu);
    }


}
