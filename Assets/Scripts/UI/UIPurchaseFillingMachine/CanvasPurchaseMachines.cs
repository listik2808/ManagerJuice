using Scripts.ButtonTrigger;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.UIPurchaseFillingMachine
{
    public class CanvasPurchaseMachines : MonoBehaviour
    {
        [SerializeField] private Button _buttonCloseCanvas;
        [SerializeField] private Button _bookmarkPayMachine;
        [SerializeField] private Image _backgroundPayMachine;
        [SerializeField] private Button _bookmarkLanchProduction;
        [SerializeField] private Image _backgroundLanchProduction;
        [SerializeField] private List<ButtonListener> _listButtonListener = new List<ButtonListener>();
        [SerializeField] private List<GameObject> _listBookmark = new List<GameObject>();
        private GameObject _activBookmark;
        public List<ButtonListener> ListButtonListener => _listButtonListener;

        private bool _isOpen = false;

        public bool IsOpen => _isOpen;

        private void OnEnable()
        {
            _bookmarkLanchProduction.onClick.AddListener(OpenBookmarkLanchProduction);
            _bookmarkPayMachine.onClick.AddListener(OpenBookmarkPayMachine);
            _buttonCloseCanvas.onClick.AddListener(CloseWindow);
            _isOpen = true;
            EnableLastBookmark();
        }

        private void OnDisable()
        {
            _bookmarkLanchProduction.onClick.RemoveListener(OpenBookmarkLanchProduction);
            _bookmarkPayMachine.onClick.RemoveListener(OpenBookmarkPayMachine);
            _buttonCloseCanvas?.onClick.RemoveListener(CloseWindow);
        }

        public void DiactivateButtonIndex(int index)
        {
            foreach (ButtonListener button in _listButtonListener)
            {
                if (button.ButtonIndex == index)
                {
                    button.ButtonMachine.interactable = false;
                    break;
                }
            }
        }

        private void CloseWindow()
        {
            _isOpen = false;
            gameObject.SetActive(false);
        }

        private void OpenBookmarkPayMachine()
        {
            _activBookmark.gameObject.SetActive(false);
            _backgroundPayMachine.gameObject.SetActive(true);
            _activBookmark = _backgroundPayMachine.gameObject;
        }

        private void OpenBookmarkLanchProduction()
        {
            _activBookmark.gameObject.SetActive(false);
            _backgroundLanchProduction.gameObject.SetActive(true);
            _activBookmark = _backgroundLanchProduction.gameObject;
        }

        private void EnableLastBookmark()
        {
            if(_activBookmark != null)
            {
                foreach (GameObject button in _listBookmark)
                {
                    if (button == _activBookmark)
                    {
                        button.gameObject.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                _activBookmark = _listBookmark[0];
                _activBookmark.gameObject.SetActive(true);
            }
        }
    }
}
