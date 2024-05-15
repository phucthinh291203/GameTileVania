using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    [SerializeField] float timeToStartNextLevel = 1f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
            return;
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(timeToStartNextLevel);
        

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }
}
