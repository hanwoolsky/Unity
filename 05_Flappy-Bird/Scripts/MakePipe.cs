using UnityEngine;

public class MakePipe : MonoBehaviour
{
    public GameObject pipe;
    float timer = 0;
    public float timeDiff = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff) {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3(3, Random.Range(-2.5f, 1.5f), 0);
            timer = 0;
            Destroy(newPipe, 15f);
        }
    }
}
