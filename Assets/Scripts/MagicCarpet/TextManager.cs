using System.Linq;
using TMPro;
using UnityEngine;

namespace MagicCarpet
{
    public class TextManager : MonoBehaviour
    {
        [SerializeField] private TMP_FontAsset[] notUsedFonts;

        private void Start()
        {
            UpdateLanguage();
        }

public void UpdateLanguage()
{
    var texts = FindObjectsOfType<TMP_Text>()
        .Where(text => !notUsedFonts.Contains(text.font));

    foreach (var text in texts)
    {
        text.SetText(Localization.Instance.Localize(text.text));
    }
}
    }
}