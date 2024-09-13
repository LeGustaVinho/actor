using System;
using System.Collections.Generic;
using LegendaryTools.Systems.AssetProvider;
using UnityEngine;

namespace LegendaryTools.Systems.Actor
{
    [Serializable]
    public class TypeOfActorAssetLoader
    {
        [TypeFilter(typeof(Actor))]
        public SerializableType SerializableType;
        public AssetLoaderConfig AssetLoaderConfig;
    }
    
    [CreateAssetMenu(menuName = "Tools/ActorSystem/ActorSystemAssetLoadableConfig", fileName = "ActorSystemAssetLoadableConfig", order = 0)]
    public class ActorSystemAssetLoadableConfig : 
#if ODIN_INSPECTOR
        Sirenix.OdinInspector.SerializedScriptableObject
#else
        ScriptableObject
#endif
    {
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.ShowInInspector]
        public Dictionary<Type, AssetLoaderConfig> TypeByActorAssetLoadersTable =
            new Dictionary<Type, AssetLoaderConfig>();
#else
        public List<TypeOfActorAssetLoader> TypeByActorAssetLoaders = 
            new List<TypeOfActorAssetLoader>();

        private Dictionary<Type, AssetLoaderConfig> TypeByActorAssetLoadersTable =
            new Dictionary<Type, AssetLoaderConfig>();
#endif

        public void Initialize()
        {
#if !ODIN_INSPECTOR
            TypeByActorAssetLoadersTable.Clear();
            foreach (TypeOfActorAssetLoader typeByActorAssetLoader in TypeByActorAssetLoaders)
            {
                if (TypeByActorAssetLoadersTable.ContainsKey(typeByActorAssetLoader.SerializableType.Type))
                {
                    Debug.LogError($"[ActorSystemAssetLoadableConfig:Initialize] Type {typeByActorAssetLoader.SerializableType.Type} already exists in ActorSystemAssetLoadableConfig");
                    break;
                }
                
                TypeByActorAssetLoadersTable.Add(typeByActorAssetLoader.SerializableType.Type, typeByActorAssetLoader.AssetLoaderConfig);
            }
#endif
        }
    }
}