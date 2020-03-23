using UnityEngine;
using UnityEngine.UI;


namespace GeekBrainsFPS
{
    public sealed class FlashLightFillerUI : MonoBehaviour
    {
        #region Fields

        private Image _image;

        #endregion


        #region Properties

        public float FillAmount
        {
            set => _image.fillAmount = value;
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.fillAmount = 1.0f;
        }

        #endregion


        #region Methods

        public void SetActive(bool value)
        {
            _image.gameObject.SetActive(value);
        }

        #endregion
    }
}