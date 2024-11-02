using UnityEngine;

[System.Serializable]
public struct SpawnableObject
{
    public GameObject prefab;
    [Range(0f, 1f)]
    public float spawnChance;
}

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SpawnableObject[] objects;

    [SerializeField]
    private float minSpawnRate;
    [SerializeField]
    private float maxSpawnRate;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (SpawnableObject obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position = obj.prefab.transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
