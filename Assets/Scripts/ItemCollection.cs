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
    public PointManager pointManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human") && pointManager.humanAP > 0)
        {
            collectedItemTextbox.SetActive(true);
            collectedItemText.text = "+1 Food";
            HideCollectible();
            gameEvents.Raise(this, null);
        }
        if (other.gameObject.CompareTag("Dog") && pointManager.dogAP > 0)
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
