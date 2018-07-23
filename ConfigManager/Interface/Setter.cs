using System;
using System.Collections.Generic;
using Nett;

namespace ConfigManager.Interface
{
    class Setter
    {
        private TomlTable _settings;

        public Setter(TomlTable settings) { _settings = settings; }

        public void AttatchComments(TomlObject field, string comment)
        {
            if (comment != "")
            {
                field.ClearComments();
                field.AddComment(comment);
            }
        }

        public TomlObject SetValueInternal(string key, bool value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, string value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, int value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, float value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, double value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, long value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, IEnumerable<bool> value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, IEnumerable<string> value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, IEnumerable<int> value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, IEnumerable<float> value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, IEnumerable<double> value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }

        public TomlObject SetValueInternal(string key, IEnumerable<long> value, string comment)
        {
            TomlObject field = _settings.ContainsKey(key) ?
                _settings.Update(key, value) :
                field = _settings.Add(key, value);

            AttatchComments(field, comment);
            return field;
        }
    }
}
