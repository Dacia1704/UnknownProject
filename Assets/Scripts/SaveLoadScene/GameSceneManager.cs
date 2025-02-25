using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
        public static GameSceneManager Instance;
        [field: SerializeField ]public string FireSceneName { get; private set; }
        [field: SerializeField ]public string LeafSceneName { get; private set; }
        [field: SerializeField ]public string WaterSceneName { get; private set; }


        private void Awake()
        {
                Instance = this;
        }

        public void LoadScene(string sceneName)
        {
                SceneManager.LoadSceneAsync(sceneName);
        }
}