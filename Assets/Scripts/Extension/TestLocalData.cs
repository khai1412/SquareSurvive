namespace Extension
{
    using System;
    using Model.LocalData.Base;
    using Model.LocalData.Data;
    using UnityEngine;

    public class TestLocalData : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                LocalDataManager.Instant.GetLocalData<GameLocalData>().currentLevel++;
                Debug.Log(LocalDataManager.Instant.GetLocalData<GameLocalData>().currentLevel);
            }
        }
    }
}