using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    //public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public GameObject[] GroundTileArrayPrefab;
    public int randomNumber;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(GroundTileArrayPrefab[randomNumber], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }

    }

    private void LateUpdate()
    {
        randomNumber = Random.Range(0, GroundTileArrayPrefab.Length);
    }

}
