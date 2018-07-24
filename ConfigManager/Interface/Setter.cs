using System;
using System.Collections.Generic;
using Nett;

namespace BeatSaberConfigManager.Interface
{
    class Setter
    {
        private TomlTable _settings;
        private readonly Action Flush;

        public Setter(TomlTable settings, Action flush) {
            _settings = settings;
            Flush = flush;
        }

        // Seriously, fuck this TOML Library.
        // WHY DOESN'T IT SUPPORT GENERICS

        public TomlObject SetValueInternal<T>(string key, T value, string comment)
        {
            TomlObject field;
            if (value is bool)
            {
                bool v = (bool)(object)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else if (value is string)
            {
                string v = (string)(object)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else if (value is int)
            {
                int v = (int)(object)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else if (value is float)
            {
                float v = (float)(object)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else
            {
                throw new NotSupportedException();
            }

            AttatchComments(field, comment);
            Flush();
            return field;
        }

        public TomlObject SetValueInternal<T>(string key, IEnumerable<T> value, string comment)
        {
            TomlObject field;
            if (typeof(T) == typeof(bool))
            {
                IEnumerable<bool> v = (IEnumerable<bool>)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else if (typeof(T) == typeof(string))
            {
                IEnumerable<string> v = (IEnumerable<string>)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else if (typeof(T) == typeof(int))
            {
                IEnumerable<int> v = (IEnumerable<int>)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else if (typeof(T) == typeof(float))
            {
                IEnumerable<float> v = (IEnumerable<float>)value;
                field = _settings.ContainsKey(key) ? _settings.Update(key, v) : field = _settings.Add(key, v);
            }
            else
            {
                throw new NotSupportedException();
            }

            AttatchComments(field, comment);
            Flush();
            return field;
        }

        void AttatchComments(TomlObject field, string comment)
        {
            if (comment != "")
            {
                field.ClearComments();
                field.AddComment(comment);
            }
        }
    }
}
