using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilitis.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private const float DeadZone = 0.01f;

        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<float> _rotationSpeed;
        private Rigidbody _rigidbody;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _rigidbody = entity.Rigidbody;
            _rotationSpeed = entity.RotationSpeed;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_moveDirection.Value.magnitude <= DeadZone)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_moveDirection.Value.normalized);
            float step = _rotationSpeed.Value * deltaTime;

            _rigidbody.rotation = Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step);
        }
    }
}
