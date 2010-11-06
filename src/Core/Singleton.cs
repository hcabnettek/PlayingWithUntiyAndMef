namespace UnityDemo.Core
{
    public class Singleton<T> where T:class , new()
    {
        private static object padlock = new object();
        static Singleton(){}
        Singleton(){}

        class SingletonCreator
        {
            static SingletonCreator(){}
            internal static readonly T instance = new T();
        }

        public static T UniqueInstance
        {
            get
            {
                lock(padlock)
                {
                    return SingletonCreator.instance;
                }
            }
        }

    }
}
