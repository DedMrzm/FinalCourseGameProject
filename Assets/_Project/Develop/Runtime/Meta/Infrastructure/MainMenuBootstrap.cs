using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilitis.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilitis.Reactive;
using Assets._Project.Develop.Runtime.Utilitis.SceneManagment;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private ReactiveVariable<int> _field;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация сцены меню");

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Старт сцены меню");

            _field = new ReactiveVariable<int>();
            _field.Subscribe(OnFieldChanged);
        }

        private void OnFieldChanged(int arg1, int arg2)
        {
            Debug.Log($"");
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerfomer coroutinesPerfomer = _container.Resolve<ICoroutinesPerfomer>();
                coroutinesPerfomer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(2)));
            }
        }
    }
}
