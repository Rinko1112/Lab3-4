using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Di chuyển về phía Player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player bị bắt!");
            collision.gameObject.transform.position = new Vector3(0, 0, 0); // Đưa Player về vị trí ban đầu
        }
    }
}
