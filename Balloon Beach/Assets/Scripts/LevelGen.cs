using System.Collections;
using UnityEngine;

public class LevelGen : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        StartCoroutine("Transfer");
    }

    private IEnumerator Transfer() {
        yield return new WaitForSeconds(1);
        gameObject.transform.parent.position = new Vector3(0, 0, gameObject.transform.position.z + 200);
        Debug.Log("Aqui");
    }
}