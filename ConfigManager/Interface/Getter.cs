using System;
using System.Collections.Generic;
using Nett;

namespace ConfigManager.Interface
{
    class Getter
    {
        private TomlTable _settings;
        private Setter _setter;

        public Getter(TomlTable settings)
        {
            _settings = settings;
            _setter = new Setter(_settings);
        }

        public bool GetValueInternal(string key, bool defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<bool>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public string GetValueInternal(string key, string defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<string>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public int GetValueInternal(string key, int defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<int>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public float GetValueInternal(string key, float defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<float>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public double GetValueInternal(string key, double defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<double>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public long GetValueInternal(string key, long defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<long>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public IEnumerable<bool> GetValueInternal(string key, IEnumerable<bool> defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<IEnumerable<bool>>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public IEnumerable<string> GetValueInternal(string key, IEnumerable<string> defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<IEnumerable<string>>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public IEnumerable<int> GetValueInternal(string key, IEnumerable<int> defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<IEnumerable<int>>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public IEnumerable<float> GetValueInternal(string key, IEnumerable<float> defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<IEnumerable<float>>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public IEnumerable<double> GetValueInternal(string key, IEnumerable<double> defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<IEnumerable<double>>(key);
            }
            catch (Exception)
            {
                if (saveDefault)
                    _setter.SetValueInternal(key, defaultValue, "");

                return defaultValue;
            }
        }

        public IEnumerable<long> GetValueInternal(string key, IEnumerable<long> defaultValue, bool saveDefault = false)
        {
            try
            {
                return _settings.Get<IEnumerable<long>>(key);
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
