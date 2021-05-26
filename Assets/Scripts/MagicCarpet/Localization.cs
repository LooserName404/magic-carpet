using System.Collections.Generic;
using System.Linq;
using MagicCarpet.Exceptions;
using UnityEngine;

namespace MagicCarpet
{
    public class Localization : MonoBehaviour
    {
        public static Localization Instance;
        // [SerializeField]
        private TextAsset _asset;
        private Dictionary<string, Dictionary<string, string>> _langTable;
        private string _currentLang;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            LoadLocalization();

            _currentLang = PlayerPrefs.GetString("language");
            
            DontDestroyOnLoad(gameObject);
        }

        private void LoadLocalization()
        {
            _asset = Resources.Load("localization") as TextAsset;
            string text = _asset.text;
            if (string.IsNullOrEmpty(text))
            {
                throw new LocalizationNotFoundException();
            }

            _langTable = new Dictionary<string, Dictionary<string, string>>();
            
            var tempTable = text
                .Split('\n')
                .Select(line =>
                    line
                        .Split(',')
                        .Select(word => word.Trim())
                        .ToArray())
                .ToArray();

            var languages = tempTable[0].Skip(1).ToArray();

            foreach (string lang in languages)
            {
                _langTable[lang] = new Dictionary<string, string>();
            }

            foreach (string[] line in tempTable.Skip(1))
            {
                string key = line[0];
                var cells = line.Skip(1).ToArray();
                
                for (int i = 0; i < cells.Length; i++)
                {
                    var lang = languages[i];
                    _langTable[lang][key] = cells[i];
                }
            }

            if (!PlayerPrefs.HasKey("language"))
            {
                SetLanguage(languages[0]);
            }
        }

        public void SetLanguage(string language)
        {
            if (!_langTable.ContainsKey(language))
            {
                throw new LocalizationNotFoundException();
            }
            
            PlayerPrefs.SetString("language", language);
            PlayerPrefs.Save();
            
            _currentLang = language;
        }

        public string Localize(string key)
        {
            return _langTable[_currentLang][key];
        }
    }
}