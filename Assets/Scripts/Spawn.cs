using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject parrotPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float sizeX = 8f;
    [SerializeField] private float cooldownTimer = 1f;

    private float spawnTime;

    private void Start()
    {
        spawnTime = cooldownTimer;
    }

    private void Update()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }

        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime = Random.Range(cooldownTimer - 0.5f, cooldownTimer + 0.5f);
        }
    }

    void Spawn()
    {
        float xPos = Random.Range(-sizeX, sizeX);
        float yPos = transform.position.y;

        Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
        Instantiate(GetRandomPrefab(), spawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomPrefab()
    {
        // Randomly choose between parrot and bomb prefab, mostly parrot will be chosen
        // to make the game more challenging, you can adjust the probability here
        return Random.Range(0, 4) == 0 ? bombPrefab : parrotPrefab; // 25% chance for bomb
        // return Random.Range(0, 2) == 0 ? parrotPrefab : bombPrefab;
    }
}