using UnityEngine;

namespace LegendaryTools.Actor
{
    public abstract class ConfigurableActor<TConfig> : Actor<ConfigurableActorMonoBehaviour<TConfig>>
        where TConfig : ActorConfig
    {
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.ShowInInspector]
#endif
        public TConfig ActorConfig { get; protected set; }
        
        public ConfigurableActor() : base()
        {
            OnPossessed += InternalOnPossessed;
        }

        protected virtual void InternalOnPossessed(Actor actor, ActorMonoBehaviour actorMonoBehaviour)
        {
            if (actorMonoBehaviour is ConfigurableActorMonoBehaviour<TConfig> configurableActorMonoBehaviour)
            {
                ActorConfig = configurableActorMonoBehaviour.Config;
            }
        }
    }
}