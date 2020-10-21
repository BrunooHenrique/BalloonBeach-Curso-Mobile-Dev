using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject player;
    public GameObject[] triangleprefabs;
    private Vector3 spawnObstaclePosition;

    private void Update() {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if (distanceToHorizon < 120) {
            SpawnTriangles();
        }
    }

    private void SpawnTriangles() {
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 20);
        Instantiate(triangleprefabs[(Random.Range(0, triangleprefabs.Length))], spawnObstaclePosition, Quaternion.identity);
    }
}