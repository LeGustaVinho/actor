using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace LegendaryTools.Systems.Actor
{
    public class ActorManager : SerializedMonoBehaviour
    {
        public List<Actor> Actors = new List<Actor>();

        public ActorMonoBehaviour[] ActorsInScene;

        private void Awake()
        {
            foreach (ActorMonoBehaviour actorMonoBehaviour in ActorsInScene)
            {
                actorMonoBehaviour.OnActorBinded += OnActorBinded;
                actorMonoBehaviour.OnActorBinded -= OnActorUnbinded;
            }
        }

        private void OnActorBinded(ActorMonoBehaviour arg1, Actor arg2)
        {
            Actors.Add(arg2);
        }
        
        private void OnActorUnbinded(ActorMonoBehaviour arg1, Actor arg2)
        {
            Actors.Remove(arg2);
        }

        [Button]
        public void CreatePlayer()
        {
            var newPlayer = new Player(true);
            newPlayer.OnDestroyed += OnDestroyed;
            Actors.Add(newPlayer);
        }

        private void OnDestroyed(Actor arg1, ActorMonoBehaviour arg2)
        {
            Actors.Remove(arg1);
        }

        [Button]
        public void CreateNpc()
        {
            var newPlayer = new Npc(true);
            newPlayer.OnDestroyed += OnDestroyed;
            Actors.Add(newPlayer);
        }
    }
}