namespace UISystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu(fileName = "UIConfig", menuName = "ScriptableObjects/UIConfig")]
    public class UIConfig : ScriptableObject
    {
        public List<UIPrefabConfig> uiPrefabConfigs = new();
        
        public GameObject GetUIPrefab(string prefabName)
        {
            if (!this.uiPrefabConfigs.Any(e => e.prefabName.Equals(prefabName))) throw new Exception($"can not find {prefabName} in config");
            return this.uiPrefabConfigs.First(e => e.prefabName.Equals(prefabName)).uiPrefab;
        }
    }

    [Serializable]
    public class UIPrefabConfig
    {
        public string     prefabName;
        public GameObject uiPrefab;
    }
}