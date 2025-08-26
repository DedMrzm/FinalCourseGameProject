using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilitis.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class CharacterControllerMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _moveSpeed;
        private ReactiveVariable<Vector3> _moveDirection;
        private CharacterController _characterController;

        public void OnInit(Entity entity)
        {
            _moveSpeed = entity.MoveSpeed;
            _moveDirection = entity.MoveDirection;
            _characterController = entity.CharacterController;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 velocity = new Vector3(_moveDirection.Value.x * _moveSpeed.Value, _moveDirection.Value.y * _moveSpeed.Value, _moveDirection.Value.z * _moveSpeed.Value);

            _characterController.Move(velocity);
        }
    }
}
