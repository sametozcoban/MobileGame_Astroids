using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField]  private GameObject[] _asteroids;
    [SerializeField] private float asteroidsSpawner = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private float timer;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Spawner();

            timer += asteroidsSpawner;
        }
    }

    private void Spawner()
    {
        int side = Random.Range(0, 4);
        Vector2 direction = Vector2.zero;
        Vector2 spawnPoint = Vector2.zero;

        switch (side)
        {
            case 0 : //Left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1 : //Right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f , Random.Range(-1f, 1f));
                break;
            case 2 : //Bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break; //Up
            case 3:
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1, 1), -1);
                break;;

        }

        Vector3 worldSpawn = _mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawn.z = 0;
        GameObject selectedAsteroid = _asteroids[Random.Range(0, _asteroids.Length)];
        GameObject ınstanceAsteroids = Instantiate(selectedAsteroid, worldSpawn, Quaternion.Euler(0, 0, Random.Range(0,360)));

        Rigidbody _rb = ınstanceAsteroids.GetComponent<Rigidbody>();
        _rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}
