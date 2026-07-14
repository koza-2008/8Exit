using UnityEngine;

public class PlayerTrackingAnomaly : MonoBehaviour
{
    [Header("プレイヤーのトランスフォーム")]
    [SerializeField] private Transform playerTransform;

    [Header("画像①：プレイヤーが左側（マイナス）にいるとき")]
    [SerializeField] private Sprite spriteLeft;

    [Header("画像②：プレイヤーが同じX座標（ほぼ正面）にいるとき")]
    [SerializeField] private Sprite spriteCenter;

    [Header("画像③：プレイヤーが右側（プラス）にいるとき")]
    [SerializeField] private Sprite spriteRight;

    [Header("正面（中央）と判定する判定の緩さ（幅）")]
    [SerializeField] private float centerThreshold = 0.5f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (playerTransform == null)
        {
            PlayerMove player = Object.FindAnyObjectByType<PlayerMove>();
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
    }

    void Update()
    {
        if (playerTransform == null || spriteRenderer == null) return;

        float diffX = playerTransform.position.x - transform.position.x;

        if (Mathf.Abs(diffX) <= centerThreshold)
        {
            spriteRenderer.sprite = spriteCenter; 
        }
        else if (diffX < 0)
        {
            spriteRenderer.sprite = spriteLeft; 
        }
        else
        {
            spriteRenderer.sprite = spriteRight; 
        }
    }
}