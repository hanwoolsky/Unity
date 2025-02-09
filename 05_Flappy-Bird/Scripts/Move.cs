using UnityEngine;

public class Move : MonoBehaviour
{
    public float PipeSpeed = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * PipeSpeed * Time.deltaTime;
    }
}
