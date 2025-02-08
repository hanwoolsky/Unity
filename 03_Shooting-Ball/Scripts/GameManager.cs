using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI textGoal;

    public int goal;
    
    [SerializeField]
    private GameObject retryBtn;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textGoal.SetText(goal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DecreaseGoal() {
        goal -= 1;
        textGoal.SetText(goal.ToString());

        if (goal <= 0) {
            SetGameOver(true);
        }
    }

    public void SetGameOver(bool isSuccess) {
        if (isGameOver == false) {
            isGameOver = true;
            Camera.main.backgroundColor = isSuccess ? Color.green : Color.red;
            Invoke("ShowRetryBtn", 1f);
        }
    }

    void ShowRetryBtn() {
        retryBtn.SetActive(true);
    }

    public void Retry() {
        SceneManager.LoadScene("SampleScene"); // 어떤 신을 로드할 것인가? Unity의 Scene 이름
    }
}
