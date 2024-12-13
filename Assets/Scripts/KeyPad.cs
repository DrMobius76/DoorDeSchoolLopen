using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ans;
    private int length;
    private string code;
    [SerializeField] private GameObject door;

    void Start()
    {
        ans.text = "";
        length = 0;
    }

    // Start is called before the first frame update
    public void Number(int number)
    {
        if (length < 4)
        {
            ans.text +=(" " + number.ToString());
            code += number.ToString();
            length++;
        }else
        {
            Debug.Log("Te Lang");
        }

    }

    public void Reset()
    {
        ans.text = "";
        length = 0;
        code = "";
    }   

    public void Submit()
    {
        if(code == "8756")
        {
            Debug.Log("correct");
            door.SetActive(false);
            length = 5;
        }else
        {
            Debug.Log("Wrong");
            Reset();
        }
    }
}
