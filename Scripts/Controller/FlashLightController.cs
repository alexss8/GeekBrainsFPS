using UnityEngine;


namespace GeekBrainsFPS
{
    public sealed class FlashLightController : BaseController, IExecute, IInitialization
    {
        #region Fields

        private FlashLightModel _flashLightModel;
        private FlashLightTextUI _flashLightTextUI;
        private FlashLightFillerUI _flashLightFillerUI;

        #endregion


        #region Methods

        public override void On()
        {
            if (IsActive) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
            base.On();
            _flashLightModel.Switch(FlashLightActiveType.On);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlashLightActiveType.Off);
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            if (!IsActive)
            {
                if (_flashLightModel.RechargeBattery())
                {
                    _flashLightTextUI.Text = _flashLightModel.BatteryChargeCurrent;
                    _flashLightFillerUI.FillAmount = _flashLightModel.GetBatteryChargeLevel();
                }
                return;
            }

            _flashLightModel.Rotation();
            if (_flashLightModel.EditBatteryCharge())
            {
                _flashLightTextUI.Text = _flashLightModel.BatteryChargeCurrent;
                _flashLightFillerUI.FillAmount = _flashLightModel.GetBatteryChargeLevel();
            }
            else
            {
                Off();
            }
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
            _flashLightTextUI = Object.FindObjectOfType<FlashLightTextUI>();
            _flashLightFillerUI = Object.FindObjectOfType<FlashLightFillerUI>();
            _flashLightTextUI.Text = _flashLightModel.BatteryChargeCurrent;
        }

        #endregion
    }
}