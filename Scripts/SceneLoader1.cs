using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class SceneLoader1 : MonoBehaviour
{
    public string sceneToLoad = "Shadowhaven_cutscene";
    public Slider loadingBar;

    void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.3f);
            loadingBar.value = progress;
            yield return null;
        }
    }
}