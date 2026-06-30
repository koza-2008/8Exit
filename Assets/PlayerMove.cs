using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float longIdleTime = 10f;

    [Header("オーディオ設定")]
    [SerializeField] private AudioSource footstepAudioSource;

    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private float idleTimer = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (footstepAudioSource == null)
        {
            footstepAudioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        bool isMoving = false;

        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
            isMoving = true;
        }
        else if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
            isMoving = true;
        }

        anim.SetBool("isWalking", isMoving);

        if (footstepAudioSource != null)
        {
            if (isMoving)
            {
                if (!footstepAudioSource.isPlaying)
                {
                    footstepAudioSource.Play();
                }
            }
            else
            {
                footstepAudioSource.Stop();
            }
        }

        if (isMoving)
        {
            idleTimer = 0f;
        }
        else
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= longIdleTime)
            {
                anim.SetTrigger("onLongIdle");
                idleTimer = 0f;
            }
        }
    }
}