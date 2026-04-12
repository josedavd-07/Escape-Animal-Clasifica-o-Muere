using UnityEngine;
using TMPro;

public class ShowAnimalInformation : MonoBehaviour
{

    void Start()
    {
        AnimalMove animal = GetComponentInParent<AnimalMove>();

        if (animal == null)
        {
            Debug.LogError("❌ No se encontró AnimalMove en este objeto");
            return;
        }

        if (animal.data == null)
        {
            Debug.LogError("❌ AnimalMove no tiene data asignada (Scriptable Object)");
            return;
        }

        AnimalFeatures data = animal.data;
        if (data == null)
        {
            Debug.LogError("No hay script Animal");
            return;
        }

        TextMeshPro texto = GetComponentInChildren<TextMeshPro>();

            if (texto == null)
        {
            Debug.LogError("❌ No se encontró TextMeshPro en los hijos");
            return;
        }

        texto.text =
            data.NombreAnimal + "\n" +
            data.DietaAnimal + "\n" +
            data.OrigenAnimal + "\n" +
            data.TipoAnimal;

            Debug.Log("✅ Texto actualizado");
    }
    
}
