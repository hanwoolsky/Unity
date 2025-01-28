using UnityEngine;

public class Heart : MonoBehaviour
{
    public Player player;

    [Header("References")]
    public GameObject[] hearts;

    private int LiveNumber = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int leftLives = player.lives;
        if (leftLives < LiveNumber) {
            hearts[leftLives].SetActive(false);
        }
    }
}
