using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace DefaultNamespace
{
    public class SceneLoaderWindow : EditorWindow
    {
        private string[] scenePaths;
        private int selectedSceneIndex = 0;

        [MenuItem("Tools/Scene Loader")]
        public static void ShowWindow()
        {
            GetWindow<SceneLoaderWindow>("Scene Loader");
        }

        private void OnEnable()
        {
            scenePaths = AssetDatabase.FindAssets("t:Scene")
                .Select(AssetDatabase.GUIDToAssetPath)
                .ToArray();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Select a Scene to Load:", EditorStyles.boldLabel);

            if (scenePaths.Length == 0)
            {
                EditorGUILayout.HelpBox("No scenes found in the project.", MessageType.Warning);
                return;
            }

            selectedSceneIndex = EditorGUILayout.Popup(selectedSceneIndex, scenePaths);

            if (GUILayout.Button("Load Selected Scene"))
            {
                LoadScene();
            }
        }

        private void LoadScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(scenePaths[selectedSceneIndex]);
            }
        }
    }
}