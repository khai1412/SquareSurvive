namespace Model.LocalData.Base
{
    using System;
    using System.Collections.Generic;
    using Extension;
    using Newtonsoft.Json;
    using UnityEngine;

    public class LocalDataManager : Singleton<LocalDataManager>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }
        
        private Dictionary<string, ILocalData> localDataCached = new();

        public ILocalData GetLocalData<TData>()
        {
            if (!this.localDataCached.TryGetValue(typeof(TData).Name, out var localData)) throw new Exception($"can not find this data {typeof(TData).Name}");
            return this.localDataCached[typeof(TData).Name];
        }

        private void AddOrUpdateLocalData(string key, ILocalData localData)
        {
            if (this.localDataCached.TryGetValue(key, out var data))
            {
                this.localDataCached[key] = data;
                return;
            }

            this.localDataCached.Add(key, localData);
        }

        public void LoadAllLocalData()
        {
            var allDataType = ReflectionExtension.GetAllClassThatDeliverType<ILocalData>();
            allDataType.ForEach(dataType => this.LoadSingleLocalData(dataType));
        }

        private ILocalData LoadSingleLocalData(Type type)
        {
            var key = type.Name;

            if (this.localDataCached.TryGetValue(key, out var cache))
            {
                return cache;
            }

            var json = PlayerPrefs.GetString(key);

            var result = string.IsNullOrEmpty(json) ? Activator.CreateInstance(type) : JsonConvert.DeserializeObject(json, type);

            this.AddOrUpdateLocalData(key, (ILocalData)result);
            return (ILocalData)result;
        }

        public void SaveAllLocalData()
        {
            foreach (var localData in this.localDataCached)
            {
                PlayerPrefs.SetString(localData.Key, JsonConvert.SerializeObject(localData.Value));
            }

            PlayerPrefs.Save();
            Debug.Log("Save Data To File");
        }
    }
}