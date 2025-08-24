﻿using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilitis.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class MoveDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class RigidbodyComponent : IEntityComponent
    {
        public Rigidbody Value;
    }
}
