using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    public TMP_Text PopupText;
    private GameObject window;
    private GameObject popupAnimator;

    private Queue<string> popupQuere; // make it different type for more detailed popup
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
