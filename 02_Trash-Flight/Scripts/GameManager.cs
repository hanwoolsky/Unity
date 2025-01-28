using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int coin = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private GameObject GameOverUI;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void IncreaseCoin() {
        coin += 1;
        scoreText.SetText(coin.ToString());
    }

    public void GameOver() {
        GameOverUI.SetActive(true);
    }
}
