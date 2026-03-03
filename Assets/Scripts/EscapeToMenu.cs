using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class EscapeToMenu : MonoBehaviour
{
    [Header("Scene to Load")]
    [Tooltip("Enter the exact name of the scene as it appears in Build Settings")]
    public string targetSceneName = "MainMenu";

    void Update()
    {
#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
#else
        if (Input.GetKeyDown(KeyCode.Escape))
#endif
        {
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        if (string.IsNullOrEmpty(targetSceneName))
        {
            Debug.LogWarning("EscapeToScene: No target scene name set!");
            return;
        }

        SceneManager.LoadScene(targetSceneName);
    }
}