using UnityEngine;
using UnityEngine.InputSystem; 

public class BailoutSwitch : MonoBehaviour
{
    [Header("近づいた時に出すテキストUI")]
    [SerializeField] private GameObject bailoutTextObject;

    [Header("スイッチを押した時に消すもの")]
    [SerializeField] private GameObject doorOpenObject; 
    [SerializeField] private GameObject handObject;

    [Header("スイッチを押した時に新しく出すもの")]
    [SerializeField] private GameObject doorClosedObject;

    private bool isPlayerInside = false;

    void Update()
    {
        bool isKeyPressed = false;
        if (Keyboard.current != null)
        {
            isKeyPressed = Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame;
        }

        if (isPlayerInside && isKeyPressed)
        {
            if (GameManager.Instance != null)
            {
                if (handObject != null)
                {
                    Collider2D handCollider = handObject.GetComponent<Collider2D>();
                    if (handCollider != null)
                    {
                        Destroy(handCollider);
                    }
                }

                GameManager.Instance.UseBailoutButton();

                if (doorOpenObject != null) doorOpenObject.SetActive(false);
                if (handObject != null) handObject.SetActive(false);

                if (doorClosedObject != null) doorClosedObject.SetActive(true);

                if (bailoutTextObject != null) bailoutTextObject.SetActive(false);

                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.enabled)
        {
            isPlayerInside = true;
            if (bailoutTextObject != null) bailoutTextObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;
            if (bailoutTextObject != null) bailoutTextObject.SetActive(false);
        }
    }
}