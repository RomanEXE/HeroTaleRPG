using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class StateText : MonoBehaviour
    {
        public static StateText Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI tmp;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void ChangeText(string text)
        {
            tmp.text = text;
        }
    }
}