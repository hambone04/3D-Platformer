using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LevelTrigger : MonoBehaviour
{
    public string nextSceneName;
    public GameObject scoreDisplayObject;
    public TextMeshProUGUI scoreText;
    public float displayDuration = 5f;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindWithTag("Score Manager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowScoreAndTransition());
        }
    }

    private IEnumerator ShowScoreAndTransition()
    {
        scoreDisplayObject.SetActive(true);
        scoreText.text = "Level Complete! Score: " + scoreManager.score;

        yield return new WaitForSeconds(displayDuration);

        SceneManager.LoadScene(nextSceneName);
    }
}