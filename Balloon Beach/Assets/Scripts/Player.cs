using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject sceneManager;
    public float playerSpeed = 1000;
    public float directionalSpeed = 20;
    public AudioClip scoreUp;
    public AudioClip damage;
    int score = 0;

    private void Update() {
        score = GetComponent<Score>().score;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(
            Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f),
            gameObject.transform.position.y,
            gameObject.transform.position.z), directionalSpeed * Time.deltaTime);
#endif
        if (score > 5) {
            GetComponent<Rigidbody>().velocity = Vector3.forward * (playerSpeed+(score*10)) * Time.deltaTime;
        } else {
            GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        }
        //MOBILE CONTROLS
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0) {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "scoreup") {
            GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
            
        }
        if (other.gameObject.tag == "triangle") {
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_Initialize>().GameOver();
        }
    }
}