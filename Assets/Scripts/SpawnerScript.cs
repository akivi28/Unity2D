using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab; 
    [SerializeField]
    private GameObject cloudPrefab; 
    private float pipeSpawnPeriod = 4.0f;
    private float cloudSpawnPeriod = 2.0f; 
    private float pipeTimeout;
    private float cloudTimeout;

    void Start()
    {
        pipeTimeout = 0.0f;
        cloudTimeout = 0.0f;
    }

    void Update()
    {
        pipeTimeout -= Time.deltaTime;
        if (pipeTimeout <= 0.0f)
        {
            SpawnPipe();
            pipeTimeout = pipeSpawnPeriod;
        }

        cloudTimeout -= Time.deltaTime;
        if (cloudTimeout <= 0.0f)
        {
            SpawnCloud();
            cloudTimeout = cloudSpawnPeriod;
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position +
            Random.Range(-2f, 2f) * Vector3.up;
    }

    private void SpawnCloud()
    {
        GameObject cloud = GameObject.Instantiate(cloudPrefab);
        // Смещение облаков чуть ниже
        cloud.transform.position = this.transform.position +
            new Vector3(Random.Range(-5f, 5f), Random.Range(2f, 4f), 5f);
    }

}
