using UnityEngine;

namespace LegendaryTools.Actor
{
    public abstract class ConfigurableActor<TConfig> : Actor<ConfigurableActorMonoBehaviour<TConfig>>
        where TConfig : ActorConfig
    {
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.ShowInInspector]
#endif
        public TConfig Config { get; private set; }
    }
}