using System;
using UnityEngine;

namespace OK.Utility {
    [Serializable]
    public class SelectionContainer<TContent, TEnum> where TEnum : Enum {
        [SerializeField] private EnumDataContainer<Selection<TContent>, TEnum> content;
        [SerializeField, Tooltip("Modifies chance of getting same option twice in a row. 1 is same chance, higher means higher chance.")] 
        private float lastChosenFactor = 1f;

        public TContent GetOne(TEnum type) {
            return content[type].GetOne(lastChosenFactor);
        }
    }
}
