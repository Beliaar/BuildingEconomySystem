﻿using Akka.Actor;
using Xenko.Engine;
using Xenko.Games;

namespace BuildingEconomy.Systems.Orders
{
    public class Build : Interfaces.IOrder
    {
        private readonly Components.ConstructionSite target;
        private readonly ComponentActorFactory<Components.ConstructionSite> componentActorFactory;

        public Build(Components.ConstructionSite target, ComponentActorFactory<Components.ConstructionSite> componentActorFactory)
        {
            this.target = target;
            this.componentActorFactory = componentActorFactory;
        }

        public bool IsComplete(Entity entity)
        {
            return target.CurrentStageProgress >= 1.0f;
        }

        public bool IsValid(Entity entity)
        {
            return entity.Get<Components.Builder>() != null;
        }

        public void Update(Entity entity, GameTime updateTime)
        {
            if (IsComplete(entity) || !IsValid(entity))
            {
                return;
            }
            // TODO: Move to entity if not near.
            IActorRef targetActor = componentActorFactory.GetOrCreateActorForComponent(target);

            targetActor.Tell(new Construction.Messages.AdvanceProgress());
        }
    }
}
