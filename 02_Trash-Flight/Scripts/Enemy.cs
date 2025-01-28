using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Weapon") {
            Destroy(gameObject);
            Destroy(collider.gameObject);
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }
}
