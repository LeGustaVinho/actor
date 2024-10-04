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
            OnPossession += InternalOnPossession;
        }

        protected virtual void InternalOnPossession(Actor actor, ActorMonoBehaviour actorMonoBehaviour)
        {
            if (actorMonoBehaviour is ConfigurableActorMonoBehaviour<TConfig> configurableActorMonoBehaviour)
            {
                ActorConfig = configurableActorMonoBehaviour.Config;
            }
        }
    }
}