using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager

public class NextLevel : MonoBehaviour
{
    private int totalCoins = 3; // Số coin cần thu thập
    private int collectedCoins = 0;

    private void Start()
    {
        collectedCoins = 0; // Đặt lại số coin thu thập
    }

    public void CollectCoin()
    {
        collectedCoins++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && collectedCoins >= totalCoins)
        {
            SceneManager.LoadScene("Level12"); // Chuyển qua Level 2
        }
    }
}
