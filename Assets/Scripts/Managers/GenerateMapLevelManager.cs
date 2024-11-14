namespace Managers
{
    using Config;
    using Elements.Map;
    using Extension;
    using UnityEngine;
    
    public class GenerateMapLevelManager : SingletonMono<GenerateMapLevelManager>
    {
        private            MapLevelController currentMapLevel;
        private            MapLevelConfig     mapLevelConfig;
        protected override void Awake()
        {
            base.Awake();
            this.mapLevelConfig = Resources.Load<MapLevelConfig>(nameof(MapLevelConfig));
        }

        public void GenerateMapLevel(int level)
        {
            var mapPrefab = this.mapLevelConfig.GetMapLevelPrefab(level);
            if (this.currentMapLevel != null)
            {
                Destroy(this.currentMapLevel.gameObject);
                this.currentMapLevel = null;
            }

            this.currentMapLevel = Instantiate(mapPrefab).GetComponent<MapLevelController>();
        }
    }
}