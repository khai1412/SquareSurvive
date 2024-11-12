using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class EditorUtility : MonoBehaviour
{
        [MenuItem("Utility/Next Scene %TAB")]
        public static void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

            EditorSceneManager.SaveOpenScenes(); 
            EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(nextSceneIndex));
        }
}
