using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
        public static SceneLoadManager Instance;
        [field: SerializeField ]public string FireSceneName { get; private set; }
        [field: SerializeField ]public string LeafSceneName { get; private set; }
        [field: SerializeField ]public string WaterSceneName { get; private set; }

        [HideInInspector] public float ProgressValue;


        private void Awake()
        {
                Instance = this;
                ProgressValue = 0f;
                DontDestroyOnLoad(this.gameObject);
        }

        public void LoadSceneImmediately(string sceneName)
        {
                SceneManager.LoadScene(sceneName);
        } 

        public void LoadSceneAsync(string sceneName)
        {
                StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
        }
        private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
        {
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
                if (loadOperation != null)
                {
                        loadOperation.allowSceneActivation = false;
                        while (loadOperation is { isDone: false })
                        {
                                ProgressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
                                yield return null;
                        }
                }
        }
}