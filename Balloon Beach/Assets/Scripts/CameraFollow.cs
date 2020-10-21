﻿using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject player;
    public int cameraDistance = 10;

    private void LateUpdate() {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(0, gameObject.transform.position.y, player.gameObject.transform.position.z - cameraDistance), Time.deltaTime * 100);
    }
}