using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RendreTransparent : MonoBehaviour
{
    public Image image; // Assurez-vous que votre GameObject a un composant Image attach�
    public float dureeFade = 1.0f; // Dur�e de la transition en secondes

    void Start()
    {
        // Assurez-vous que l'image est attribu�e dans l'�diteur Unity ou recherchez-la automatiquement
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
            // R�cup�rez la couleur actuelle de l'image
            Color couleurActuelle = image.color;

            // Initialisez l'opacit� � 1.0 (compl�tement opaque)
            float opacite = 1.0f;

            // Calculez le changement d'opacit� par �tape
            float deltaOpacite = Time.deltaTime / dureeFade;

            // Boucle de transition
            while (opacite > 0)
            {
                opacite -= deltaOpacite;

                // Appliquez la nouvelle opacit� � la couleur de l'image
                couleurActuelle.a = opacite;

                // Appliquez la nouvelle couleur � l'image
                image.color = couleurActuelle;

                // Attendre jusqu'au prochain frame
                yield return null;
            }
        }
        else
        {
            Debug.LogError("Le composant Image n'a pas �t� trouv� sur cet objet.");
        }
    }
}
