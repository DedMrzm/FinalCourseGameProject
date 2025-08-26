using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _entity;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();   
        }

        public void Run()
        {
            _isRunning = true;
        }

        public void Update()
        {
            if(_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _entity = _entitiesFactory.CreateBasedOnRigidbodyEntity(Vector3.zero);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _entity = _entitiesFactory.CreateBasedOnCharacterControllerEntity(Vector3.zero);
            }

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if(_entity != null)
                _entity.MoveDirection.Value = input;
        }
    }
}
