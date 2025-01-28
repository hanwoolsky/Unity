using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D CoinRigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinGenerate();
    }

    void coinGenerate() {
        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f, 2f);
        CoinRigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) {
            Destroy(gameObject);
        }
    }
}
