namespace Extension
{
    using Model.LocalData.Base;
    using UnityEngine;

    public class AppService : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            Application.targetFrameRate = 90;
        }
        private void OnApplicationPause(bool pauseStatus)
        {
            Debug.Log("Save local data");
            LocalDataManager.Instant.SaveAllLocalData();
        }

        private void OnApplicationQuit()
        {
            Debug.Log("Save local data");
            LocalDataManager.Instant.SaveAllLocalData();
        }
    }
}