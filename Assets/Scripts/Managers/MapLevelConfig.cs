namespace Managers
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "MapLevelConfig", menuName = "ScriptableObjects/MapLevelConfig")]
    public class MapLevelConfig : ScriptableObject
    {
        public List<MapLevelData> listMapLevelData = new();
    }

    [Serializable]
    public class MapLevelData
    {
        public int        level;
        public GameObject prefabName;
    }
}