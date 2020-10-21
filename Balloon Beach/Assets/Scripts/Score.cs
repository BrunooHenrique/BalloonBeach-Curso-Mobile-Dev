using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {
    public int score = 0;
    public int highScore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;

    private void Start() {

        highScore = PlayerPrefs.GetInt("highscore");
    }

    private void Update() {
        scoreUI.text = score.ToString();
        highScoreUI.text = highScore.ToString();
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "scoreup") {
            score++;
        }
    }
}