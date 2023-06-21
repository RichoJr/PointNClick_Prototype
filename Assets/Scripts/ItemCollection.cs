using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public GameObject collectedItemTextbox;
    public Text collectedItemText;
    public GameEvents gameEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            collectedItemTextbox.SetActive(true);
            collectedItemText.text = "+1 Food";
            HideCollectible();
            gameEvents.Raise(this, null);
        }
        if (other.gameObject.CompareTag("Dog"))
        {
            collectedItemTextbox.SetActive(true);
            collectedItemText.text = "+1 Food";
            HideCollectible();
            gameEvents.Raise(this, null);
        }
    }

    private void HideCollectible()
    {
        this.gameObject.SetActive(false);
    }
}
