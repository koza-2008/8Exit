using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class TitleCode : MonoBehaviour
{
    [Header("ゲーム本編のシーン名")]
    [SerializeField] private string gameSceneName = "GameScene";

    void Update()
    {
        bool shouldStartGame = false;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.sKey.wasPressedThisFrame ||
                Keyboard.current.enterKey.wasPressedThisFrame)
            {
                shouldStartGame = true;
            }
        }

        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                shouldStartGame = true;
            }
        }

        if (shouldStartGame)
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}