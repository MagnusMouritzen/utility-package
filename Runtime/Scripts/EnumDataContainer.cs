using UnityEngine;
using System;
using System.Collections;

namespace OK.Utility {
    [Serializable]
    public class EnumDataContainer<TValue, TEnum> : IEnumerable where TEnum : Enum {
        [SerializeField] private TValue[] content;

        public TValue this[int i] {
            get => content[i];
            set => content[i] = value;
        }

        public TValue this[TEnum i] {
            get => content[Convert.ToInt32(i)];
            set => content[Convert.ToInt32(i)] = value;
        }

        public int Length => content.Length;

        public IEnumerator GetEnumerator() {
            return content.GetEnumerator();
        }
    }
}
