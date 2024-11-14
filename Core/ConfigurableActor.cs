using UnityEngine;

namespace LegendaryTools.Actor
{
    public abstract class ConfigurableActor<TConfig> : Actor<ConfigurableActorMonoBehaviour<TConfig>>
        where TConfig : ScriptableObject
    {
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.ShowInInspector]
#endif
        public TConfig ActorConfig { get; protected set; }
        
        public ConfigurableActor() : base()
        {
        }
        
        public ConfigurableActor(bool autoCreateGameObject) : base(autoCreateGameObject)
        {
        }

        public ConfigurableActor(GameObject prefab = null, string name = "") : base(prefab, name)
        {
        }

        public ConfigurableActor(ConfigurableActorMonoBehaviour<TConfig> actorBehaviour) : base(actorBehaviour)
        {
        }
        
        public override bool Possess(ActorMonoBehaviour target)
        {
            bool result = base.Possess(target);
            if (result && target is ConfigurableActorMonoBehaviour<TConfig> configurableActorMonoBehaviour)
            {
                ActorConfig = configurableActorMonoBehaviour.Config;
            }
            return result;
        }
    }
}