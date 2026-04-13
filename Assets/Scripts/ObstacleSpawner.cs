using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] animales;      // Prefabs de animales
    public Transform[] spawnPoints;    // Puntos donde aparecen

    private float time;                // Contador de tiempo
    public float spawnDelay = 3f;      // Tiempo entre spawns

    public bool canSpawn = true;

    public int maxAnimales = 10;       // Límite de animales a generar
    private int currentAnimales = 0;   // Cantidad generada

    void Start()
    {
        animales = Resources.LoadAll<GameObject>("Animals");

        if (animales.Length == 0)
        {
            Debug.LogError("No se encontraron animales en Resources/Animals");
            canSpawn = false;
            enabled = false;
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("No hay puntos de spawn asignados en el ObstacleSpawner.");
            canSpawn = false;
            enabled = false;
        }
    }

    void Update()
    {
        if (!canSpawn) return;

        time += Time.deltaTime;

        if (time >= spawnDelay)
        {
            SpawnAnimal();
            time = 0;
        }
    }

    void SpawnAnimal()
    {
        if (currentAnimales >= maxAnimales)
        {
            StopSpawner();
            return;
        }

        int animalIndex = Random.Range(0, animales.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject animalInstanciado = Instantiate(
            animales[animalIndex],
            spawnPoints[spawnIndex].position,
            Quaternion.identity
        );

        animalInstanciado.name = animales[animalIndex].name;
        currentAnimales++;

        if (currentAnimales >= maxAnimales)
        {
            StopSpawner();
        }
    }

    void StopSpawner()
    {
        canSpawn = false;
        enabled = false;
        Debug.Log("Spawner deshabilitado: se alcanzó el límite de animales.");
    }
}
