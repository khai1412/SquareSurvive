namespace Extension
{
    using UnityEngine;

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour  
    {
        private static T instant = null;
        
        public static T Instant
        {
            get
            {
                if (instant == null)
                {
                    instant = FindObjectOfType<T>();
                }
                return instant;
            }
        } 
       
        protected virtual void Awake()
        {
            if (instant != null && instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
                Destroy(this.gameObject);
            else
                instant = this.GetComponent<T>();
        }
    }
}