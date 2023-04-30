using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    //public GameObject ObstaclePrefab;

    public Transform[] obstacleArrayPrefab;
    public int randomNumber;
    bool obstacleSpawned = false;

    bool obstacleSpawned2 = false;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0, obstacleArrayPrefab.Length); 
        if (obstacleSpawned == false)
        {
            SpawnObstacles();

        }        
        
        if (obstacleSpawned2 == false)
        {
            SpawnObstacles();

        }
    }

    void SpawnObstacles()
    {
        //Choose a random point to spawn a obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //Spawn the obstacle at the position
        Instantiate(obstacleArrayPrefab[randomNumber], spawnPoint.position, Quaternion.identity, transform);

        obstacleSpawned = true;

        //Spawn 2nd set of obstacles
        int obstacleSpawnIndex2 = Random.Range(5, 8);
        Transform spawnPoint2 = transform.GetChild(obstacleSpawnIndex2).transform;

        //Spawn the obstacle at the position
        Instantiate(obstacleArrayPrefab[randomNumber], spawnPoint2.position, Quaternion.identity, transform);

        obstacleSpawned2 = true;
    }   

}
