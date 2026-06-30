using UnityEngine;

public class LoopWarp : MonoBehaviour
{
    [SerializeField] private float warpToX = 10f;
    [SerializeField] private bool isForwardTrigger = false; //¶‰E‚Ì³‰ğ”»’è’Ç‰Á

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //³‰ğ”»’è
            if (GameManager.Instance != null)
            {
                GameManager.Instance.PlayerSelect(isForwardTrigger);
            }

            //ƒ[ƒv
            Vector3 pos = collision.transform.position;
            pos.x = warpToX;
            collision.transform.position = pos;
        }
    }
}