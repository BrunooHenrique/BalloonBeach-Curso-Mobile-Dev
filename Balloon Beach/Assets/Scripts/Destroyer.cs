using UnityEngine;

public class Destroyer : MonoBehaviour {
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (gameObject.transform.position.z < player.transform.position.z - 20) {
            Destroy(gameObject);
        }
    }
}