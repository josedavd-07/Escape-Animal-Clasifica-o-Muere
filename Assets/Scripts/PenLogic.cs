using UnityEngine;


public class PenLogic : MonoBehaviour
{
    public enum TipoCorral
    {
        Dieta,
        Origen,
        Tipo
    }

    [Header("Configuracion del corral")]
    [SerializeField] private TipoCorral tipoCorral;
    [SerializeField] private Diet dietaCorrecta;
    [SerializeField] private Origin origenCorrecto;
    [SerializeField] private Type tipoCorrecto;

    [Header("Expulsion del animal")]
    [SerializeField] private float fuerzaExpulsion = 8f;
    [SerializeField] private float fuerzaVertical = 4f;

    private void ChooseOptions()
    {
        int randomValue = Random.Range(0, System.Enum.GetValues(typeof(Diet)).Length);
        dietaCorrecta = (Diet)randomValue;

        randomValue = Random.Range(0, System.Enum.GetValues(typeof(Origin)).Length);
        origenCorrecto = (Origin)randomValue;
        
        randomValue = Random.Range(0, System.Enum.GetValues(typeof(Type)).Length);
        tipoCorrecto = (Type)randomValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        AnimalMove animal = other.GetComponent<AnimalMove>();

        if (animal == null || animal.data == null)
        {
            return;
        }

        AnimalFeatures data = animal.data;
        bool esCorrecto = false;

        switch (tipoCorral)
        {
            case TipoCorral.Dieta:
                esCorrecto = data.DietaAnimal == dietaCorrecta;
                break;
            case TipoCorral.Origen:
                esCorrecto = data.OrigenAnimal == origenCorrecto;
                break;
            case TipoCorral.Tipo:
                esCorrecto = data.TipoAnimal == tipoCorrecto;
                break;
        }

        Debug.Log(esCorrecto ? "Correcto" : "Incorrecto");

        if (esCorrecto)
        {
            animal.transform.position = transform.position;
        }
        else
        {
            ExpulsarAnimal(animal, other);
        }
    }

    private void ExpulsarAnimal(AnimalMove animal, Collider other)
    {
        Vector3 direccion = (animal.transform.position - transform.position).normalized;

        if (direccion == Vector3.zero)
        {
            direccion = -transform.forward;
        }

        direccion.y = 0f;
        direccion.Normalize();

        Vector3 fuerzaFinal = (direccion * fuerzaExpulsion) + (Vector3.up * fuerzaVertical);
        Rigidbody animalRb = other.attachedRigidbody != null ? other.attachedRigidbody : animal.GetComponent<Rigidbody>();

        if (animalRb != null)
        {
            animalRb.linearVelocity = Vector3.zero;
            animalRb.AddForce(fuerzaFinal, ForceMode.Impulse);
            return;
        }

        animal.transform.position += fuerzaFinal * 0.25f;
    }

    public void Start()
    {
        ChooseOptions();
    }
}
