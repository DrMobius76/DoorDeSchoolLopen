using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoShower : MonoBehaviour
{
    public GameObject RedKeyCard;
    public GameObject BlueKeyCard;
    public GameObject GreenKeyCard;

    public VRItemInteractor Interactor;

    public GameObject infoScreen;
    public TextMeshProUGUI infoText;

    // Colors for the keycard text
    private Color redColor = Color.red;
    private Color blueColor = Color.blue;
    private Color yellowColor = Color.yellow;

    private void Start()
    {
        // Ensure the infoScreen is disabled at the start
        infoScreen.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the player is inside the collider
        if (Interactor != null && Interactor.KeyItem != null)
        {
            string keyText = "";
            Color keyColor = Color.white;

            // Determine the keycard text and color
            if (Interactor.KeyItem == RedKeyCard)
            {
                keyText = "Red KeyCard";
                keyColor = redColor;
            }
            else if (Interactor.KeyItem == BlueKeyCard)
            {
                keyText = "Blue KeyCard";
                keyColor = blueColor;
            }
            else if (Interactor.KeyItem == GreenKeyCard)
            {
                keyText = "Yellow KeyCard";
                keyColor = yellowColor;
            }
            
            // Update the infoScreen text and color
            infoScreen.SetActive(true);
            infoText.text = $"This deur needs a <color=#{ColorUtility.ToHtmlStringRGB(keyColor)}>{keyText}</color> to open.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Disable the infoScreen when the player leaves the collider
        infoScreen.SetActive(false);
    }
}
