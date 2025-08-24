﻿using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilitis.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _contatiner;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        public EntitiesFactory(DIContainer contatiner)
        {
            _contatiner = contatiner;
            _entitiesLifeContext = _contatiner.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _contatiner.Resolve<MonoEntitiesFactory>();
        }

        public Entity CreateTestEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/TestEntity");

            entity
                .AddComponent(new MoveDirection() { Value = new ReactiveVariable<Vector3>(Vector3.forward)})
                .AddComponent(new MoveSpeed() { Value = new ReactiveVariable<float>(10)});
            
            entity.AddSystem(new MovementSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}
