using UnityEngine;

namespace LegendaryTools.Actor
{
    public abstract class ConfigurableActorMonoBehaviour<T> : ActorMonoBehaviour
        where T : ScriptableObject
    {
        public T Config;
    }
}
