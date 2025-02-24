using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.ButtonTrigger
{
    public class ButtonListener : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private int _buttonIndex;

        public Action<int> ClickButton;

        public int ButtonIndex => _buttonIndex;
        public Button ButtonMachine => _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClickEvent);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickEvent);
        }

        private void OnClickEvent()
        {
            ClickButton?.Invoke(_buttonIndex);
        }
    }
}
