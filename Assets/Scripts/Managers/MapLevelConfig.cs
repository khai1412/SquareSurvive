namespace Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu(fileName = "MapLevelConfig", menuName = "ScriptableObjects/MapLevelConfig")]
    public class MapLevelConfig : ScriptableObject
    {
        public List<MapLevelData> listMapLevelData = new();
        public GameObject         GetMapLevelPrefab(int level) => this.listMapLevelData.First(e => e.level == level).prefab;
    }

    [Serializable]
    public class MapLevelData
    {
        public int        level;
        public GameObject prefab;
    }
}