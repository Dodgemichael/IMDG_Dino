using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject1
    {
        public GameObject prefab1;
        [Range(0f, 1f)]
        public float spawnChance1;
    }

    public SpawnableObject1[] objects1;

    public float minSpawnRate1 = 1f;
    public float maxSpawnRate1 = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate1, maxSpawnRate1));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance1 = Random.value;

        foreach (var obj in objects1)
        {
            if (spawnChance1 < obj.spawnChance1)
            {
                GameObject obstacle = Instantiate(obj.prefab1);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance1 -= obj.spawnChance1;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate1, maxSpawnRate1));
    }

}