using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

namespace UI
{
    public class ChangeLocale : MonoBehaviour
    {
        private List<Locale> _locales = new();

        private void Start()
        {
            _locales = LocalizationSettings.AvailableLocales.Locales;
            var localizeSpriteEvent = GetComponent<LocalizeSpriteEvent>();
            localizeSpriteEvent.OnUpdateAsset?.Invoke(localizeSpriteEvent.AssetReference.LoadAsset());
        }

        public void Change()
        {
            if (_locales.Count == 0) Start();
            if (_locales.Count == 0) return;
            LocalizationSettings.SelectedLocale = _locales[(_locales.IndexOf(LocalizationSettings.SelectedLocale) + 1) % _locales.Count];
        }
    }
}
