using Scripts.Triggers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Shop
{
    public class ShopData : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TMP_Text _textLevel;
        [SerializeField] private Button _buttonClose;
        [SerializeField] private Button _buttonSellShop;
        [SerializeField] private Image _progres;

        private float _level = 0;
        private float _currentCountProdect = 0;
        private float _maxProduct = 10;

        public Action<float> OnChangeProgress;

        private void OnEnable()
        {
            _buttonClose.onClick.AddListener(CloseWindow);
            _buttonSellShop.onClick.AddListener(PayShop);
            OnChangeProgress += ChangeProgress;
        }

        private void OnDisable()
        {
            _buttonClose.onClick?.RemoveListener(CloseWindow);
            _buttonSellShop.onClick?.RemoveListener(PayShop);
            OnChangeProgress -= ChangeProgress;
        }

        public void CloseWindow()
        {
            _canvas.gameObject.SetActive(false);
        }

        public void OpenWindow()
        {
            _canvas.gameObject.SetActive(true);
        }

        private void ShowLevel()
        {
            _textLevel.text = _level.ToString();
        }

        private void ChangeProgress(float value)
        {
            _currentCountProdect += value;
            if(_currentCountProdect >= _maxProduct)
            {
                float count = _currentCountProdect - _maxProduct;
                _level += 1;
                _maxProduct += 5;
                _currentCountProdect = count;
            }
            _progres.fillAmount = _currentCountProdect / _maxProduct;
        }

        private void PayShop()
        {

        }
    }
}
