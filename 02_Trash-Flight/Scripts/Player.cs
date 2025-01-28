using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.2f;
    private float lastShotTime = 0f;
    
    public int lives = 3;

    public float JumpForce = 3f;
    public Rigidbody2D PlayerRigidBody;
    public CircleCollider2D PlayerCollider;
    public GameObject EnemySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void moveByAxis(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;
    }

    void moveByMouse() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); // 화면 밖으로 캐릭터 안 벗어나게
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= moveTo;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += moveTo;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void Shoot() {
        if (Time.time - lastShotTime > shootInterval) {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            Destroy(collider.gameObject);
            Hit();
        } else if (collider.gameObject.tag == "Coin") {
            Destroy(collider.gameObject);
            GameManager.instance.IncreaseCoin();
        }
    }

    void Hit() {
        lives -= 1;
        if (lives == 0) {
            KillPlayer();
            GameManager.instance.GameOver();
        }
    }

    void KillPlayer(){
        PlayerRigidBody.gravityScale = 1f;
        PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse); // 마지막에 Jump 한번 하고 죽기
        EnemySpawner.SetActive(false);
    }
}
