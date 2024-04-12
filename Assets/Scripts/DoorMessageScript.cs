using UnityEngine;
using TMPro;

public class DoorMessageScript : MonoBehaviour
{
    public DoorController dc;

    public TextMeshProUGUI textMeshPro;

    private void Start()
    {

        textMeshPro.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            if (!dc.isUnlocked)
            {
                textMeshPro.enabled = true;
                textMeshPro.text = "Need Key";
            }
            if (dc.isUnlocked)
            {
                textMeshPro.enabled = true;
                textMeshPro.text = "Unlocked";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            textMeshPro.enabled = false; 
        }
    }
}
