using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager
using UnityEngine.UI; // Import UI

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector3 startPosition;

    public GameObject winText;
    private int coinCount = 0; // Đếm số Coin đã thu thập
    private int totalCoins; // Tổng số Coin trong màn chơi

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        // Kiểm tra nếu winText chưa được gán
        if (winText != null)
        {
            winText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("⚠ winText chưa được gán trong Inspector!");
        }

        // Đếm số Coin có trong Scene
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed; // Sửa lỗi linearVelocity → velocity
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount++;
            Debug.Log("Coins Collected: " + coinCount + "/" + totalCoins);
        }

        if (other.CompareTag("Goal"))
        {
            if (coinCount >= totalCoins)
            {
                if (winText != null)
                {
                    winText.SetActive(true);
                }
                Debug.Log("You Win!");

                // Chuyển sang Level tiếp theo sau 2 giây
                Invoke("LoadNextLevel", 2f);
            }
            else
            {
                Debug.Log("⚠ Chưa đủ Coin! Hãy thu thập hết trước khi đến đích.");
            }
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("💀 Chạm vào Enemy! Hồi sinh...");
            transform.position = startPosition; // Quay lại điểm xuất phát
            rb.linearVelocity = Vector2.zero; // Reset vận tốc
        }
    }

    private void LoadNextLevel()
    {
        // Kiểm tra nếu Scene tồn tại trước khi load
        if (Application.CanStreamedLevelBeLoaded("Level12"))
        {
            SceneManager.LoadScene("Level12");
        }
        else
        {
            Debug.LogError("🚨 Scene 'Level12' chưa được thêm vào Build Settings! Hãy kiểm tra.");
        }
    }
}
