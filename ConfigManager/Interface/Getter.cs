using System;
using System.Collections.Generic;
using Nett;

namespace BeatSaberConfigManager.Interface
{
    class Getter
    {
        private TomlTable _settings;
        private Setter _setter;

        public Getter(TomlTable settings, Action Flush)
        {
            _settings = settings;
            _setter = new Setter(_settings, Flush);
        }

        public T GetValueInternal<T>(string key, T defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<T>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public List<T> GetValueInternal<T>(string key, List<T> defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<List<T>>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }
    }
}
