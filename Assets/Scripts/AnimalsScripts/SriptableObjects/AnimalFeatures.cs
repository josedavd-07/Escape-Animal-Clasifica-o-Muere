using UnityEngine;

public enum AnimalName
{
    Beaver,
    Bunny,
    Cat,
    Cow,
    Deer,
    Dog,
    Elephant,
    Fox,
    Giraffe,
    Hog,
    Lion,
    Monkey
}

public enum Diet
{
    Herbivore,
    Carnivore,
    Omnivore
}

public enum Origin
{
    Salvage,
    Domestic
}

public enum Type
{
    Dangerous,
    Useful,
    Neuter
}

[CreateAssetMenu(menuName = "Animal", fileName = "NewAnimalFeatures")]

public class AnimalFeatures : ScriptableObject
{
    [SerializeField] public AnimalName nombreAnimal;
    [SerializeField] public Diet dieta;
    [SerializeField] public Origin origen;
    [SerializeField] public Type tipo;

    public AnimalName NombreAnimal => nombreAnimal;
    public Diet DietaAnimal => dieta;
    public Origin OrigenAnimal => origen;
    public Type TipoAnimal => tipo;
}
