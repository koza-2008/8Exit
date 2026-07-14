using UnityEngine;

public class DistanceAnimationAnomaly : MonoBehaviour
{
    [Header("プレイヤーのトランスフォーム")]
    [SerializeField] private Transform playerTransform;

    [Header("段階ごとの画像（4枚必ず設定してください）")]
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;

    [Header("変化が始まり、終わる「距離」の設定")]
    [Tooltip("この距離（マス）より遠いときは画像①になります")]
    [SerializeField] private float startDistance = 5.0f;

    [Tooltip("この距離（マス）より近づいたら完全に画像④になります")]
    [SerializeField] private float targetDistance = 0.2f;

    private SpriteRenderer spriteRenderer;

    private float lockedY;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        lockedY = transform.position.y;

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
        transform.position = new Vector3(transform.position.x, lockedY, transform.position.z);

        if (playerTransform == null || spriteRenderer == null) return;

        float distanceX = Mathf.Abs(playerTransform.position.x - transform.position.x);

        float t = Mathf.InverseLerp(targetDistance, startDistance, distanceX);

        if (t > 0.75f)
        {
            spriteRenderer.sprite = sprite1;
        }
        else if (t > 0.5f)
        {
            spriteRenderer.sprite = sprite2;
        }
        else if (t > 0.25f)
        {
            spriteRenderer.sprite = sprite3;
        }
        else
        {
            spriteRenderer.sprite = sprite4;
        }
    }
}