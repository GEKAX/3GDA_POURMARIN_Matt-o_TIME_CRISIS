using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RendreTransparent : MonoBehaviour
{
    public Image image; // Assurez-vous que votre GameObject a un composant Image attaché
    public float dureeFade = 1.0f; // Durée de la transition en secondes

    void Start()
    {
        // Assurez-vous que l'image est attribuée dans l'éditeur Unity ou recherchez-la automatiquement
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        // Appel de la fonction pour rendre progressivement l'image transparente
        StartCoroutine(RendreImageProgressivementTransparente());
    }

    IEnumerator RendreImageProgressivementTransparente()
    {
        if (image != null)
        {
            // Récupérez la couleur actuelle de l'image
            Color couleurActuelle = image.color;

            // Initialisez l'opacité à 1.0 (complètement opaque)
            float opacite = 1.0f;

            // Calculez le changement d'opacité par étape
            float deltaOpacite = Time.deltaTime / dureeFade;

            // Boucle de transition
            while (opacite > 0)
            {
                opacite -= deltaOpacite;

                // Appliquez la nouvelle opacité à la couleur de l'image
                couleurActuelle.a = opacite;

                // Appliquez la nouvelle couleur à l'image
                image.color = couleurActuelle;

                // Attendre jusqu'au prochain frame
                yield return null;
            }
        }
        else
        {
            Debug.LogError("Le composant Image n'a pas été trouvé sur cet objet.");
        }
    }
}
