using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
	public void PlayGame()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		SceneManager.LoadSceneAsync(1);
	}
	
	public void QuitGame() {
		Application.Quit();
	}
}
