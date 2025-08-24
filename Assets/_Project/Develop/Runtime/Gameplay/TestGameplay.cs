using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
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

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();   
        }

        public void Run()
        {
            Entity entity = _entitiesFactory.CreateTestEntity(Vector3.zero);

            Debug.Log("Направление движения: " + entity.GetComponent<MoveDirection>().Value.Value.ToString());
            Debug.Log("Скорость движения: " + entity.GetComponent<MoveSpeed>().Value.Value.ToString());

            _isRunning = true;
        }

        public void Update()
        {
            if(_isRunning == false)
                return;
        }
    }
}
