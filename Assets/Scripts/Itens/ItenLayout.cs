using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Itens
{

    public class ItenLayout : MonoBehaviour
    {
        private ItemSetup _CurSetup;

        public Image uiIcon;
        public TextMeshProUGUI uiValue;
        public void Load(ItemSetup setup)
        {
            _CurSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _CurSetup.icon;
        }

        private void Update()
        {
            uiValue.text = _CurSetup.soInt.value.ToString();
        }
    }

}