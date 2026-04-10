using UnityEngine;

public enum Dieta
{
    Herbivore,
    Carnivore,
    Omnivore
}

public enum Origen
{
    Salvage,
    Domestic
}

public enum Tipo
{
    Dangerous,
    Useful,
    Neuter
}

[CreateAssetMenu(menuName = "Animal", fileName = "NewAnimalFeatures")]
public class AnimalFeatures : ScriptableObject
{
    [SerializeField] private Dieta dieta;
    [SerializeField] private Origen origen;
    [SerializeField] private Tipo tipo;

    public Dieta DietaAnimal => dieta;
    public Origen OrigenAnimal => origen;
    public Tipo TipoAnimal => tipo;

}
