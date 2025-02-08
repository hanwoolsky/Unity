using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = -140f; // 음수면 시계 방향, 양수면 반 시계 방향

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false) {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }
}
