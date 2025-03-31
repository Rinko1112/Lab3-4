using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tìm NextLevel an toàn theo Unity mới
            NextLevel nextLevel = FindFirstObjectByType<NextLevel>();

            if (nextLevel != null)
            {
                nextLevel.CollectCoin(); // Gọi hàm CollectCoin khi Player nhặt Coin
            }

            Destroy(gameObject); // Xóa Coin sau khi thu thập
        }
    }
}
