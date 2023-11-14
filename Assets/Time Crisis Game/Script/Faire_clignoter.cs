using UnityEngine;
using TMPro;
using System.Net;
using UnityEngine.Events;

public class ClignotementTextMeshPro : MonoBehaviour
{
    private TextMeshProUGUI texteMeshPro;
    public float tauxClignotement = 1.0f; // Nombre de clignotements par seconde
    public bool peut_clignoter = false;

    void Start()
    {
        texteMeshPro = GetComponent<TextMeshProUGUI>();
        ClignoterTexte();
    }

    public void ClignoterTexte()
    {
        peut_clignoter = true;
        while (peut_clignoter == true)
        {
            texteMeshPro.enabled = !texteMeshPro.enabled;
            new WaitForSeconds(1f / tauxClignotement);
        }
    }
}





