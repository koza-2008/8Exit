using UnityEngine;

public class LoopAnimationAnomaly : MonoBehaviour
{
    [Header("Sprites (1-8)")]
    [SerializeField] private Sprite[] animationSprites;

    [Header("Frame Rate (fps)")]
    [SerializeField] private float frameRate = 10f;

    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private int currentFrameIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        currentFrameIndex = 0;
        timer = 0f;
        UpdateSprite();
    }

    void Update()
    {
        if (spriteRenderer == null || animationSprites == null || animationSprites.Length == 0) return;

        timer += Time.deltaTime;

        float timePerFrame = 1f / frameRate;
        if (timer >= timePerFrame)
        {
            timer -= timePerFrame;
            currentFrameIndex = (currentFrameIndex + 1) % animationSprites.Length;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        if (spriteRenderer != null && animationSprites.Length > currentFrameIndex)
        {
            spriteRenderer.sprite = animationSprites[currentFrameIndex];
        }
    }
}