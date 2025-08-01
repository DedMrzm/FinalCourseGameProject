using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _mainGroup;

        private void Awake()
        {
            _mainGroup.alpha = 0;
        }

        public void OnCloseButtonClick() => CloseRequest?.Invoke();

        public void Show()
        {
            OnPreShow();

            //анимации
            _mainGroup.alpha = 1;

            OnPostShow();
        }


        public void Hide()
        {
            OnPreHide();

            //анимации
            _mainGroup.alpha = 0;

            OnPostHide();
        }
        protected virtual void OnPostShow() { }

        protected virtual void OnPreShow() { }

        protected virtual void OnPostHide() { }

        protected virtual void OnPreHide() { }
    }
}
