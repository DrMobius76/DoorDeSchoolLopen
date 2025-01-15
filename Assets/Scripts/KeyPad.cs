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
    [SerializeField] private GameObject[] doors;

    void Start()
    {
        ans.text = "";
        length = 0;
        code = "";
    }

    // Function to handle number input
    public void Number(int number)
    {
        if (length < 4)
        {
            ans.text += " " + number.ToString(); // Append the number to the displayed code
            code += number.ToString(); // Append the number to the actual code
            length++;
        }
        else
        {
            Debug.Log("Code is too long.");
        }
    }

    // Reset the input
    public void Reset()
    {
        ans.text = "";
        length = 0;
        code = "";
    }

    // Submit the code and check its correctness
    public void Submit()
    {
        if (code == "8756") // Correct code
        {
            Debug.Log("Correct code entered.");
            foreach (GameObject door in doors)
            {
                door.SetActive(false); // Disable doors
            }
            Reset();
        }
        else // Incorrect code
        {
            Debug.Log("Incorrect code entered.");
            Reset();
        }
    }
}
