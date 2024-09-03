using UnityEngine;

public class Fogspawner : MonoBehaviour
{
    private float timer;
    [SerializeField] private float spawntime;
    [SerializeField] private float heightOffset;
    [SerializeField] private GameObject fogPrefab;
    [SerializeField] private Transform spawnPosition;

    void Start()
    {
        SpawnFog();
    }

    void Update()
    {

        if (timer > spawntime)
        {
            SpawnFog();
        }
        else
            timer += Time.deltaTime;
    }
    void SpawnFog()
    {
        float lowestpoint = 3.6f;
        float highestpoint = 14.6f;
        Instantiate(fogPrefab, new Vector3(spawnPosition.position.x + Random.Range(-2f, 2f), Random.Range(lowestpoint, highestpoint), 0), Quaternion.identity);
        timer = 0;
    }
}
