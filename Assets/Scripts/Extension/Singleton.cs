namespace Extension
{
    public class Singleton<T> where T : new()
    {
        private static T instant;
        
        public static T Instant
        {
            get
            {
                if (instant == null)
                {
                    instant = new T();
                }
                return instant;
            }
        }
    }
}