using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    private bool isPinned = false;
    private bool isLaunched = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPinned == false && isLaunched == true) {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        isPinned = true;
        if (collider.gameObject.tag == "Target") {
            GameObject childObject = transform.Find("Line").gameObject;
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            childSprite.enabled = true;

            transform.SetParent(collider.gameObject.transform);

            GameManager.instance.DecreaseGoal();
        } else if (collider.gameObject.tag == "Pin") {
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch() {
        isLaunched = true;
    }
}
