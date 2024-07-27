using System;
using UnityEngine;

namespace OK.Utility {
    [Serializable]
    public class Some<T> {
        public bool isSome;

        [SerializeField] private T _value;

        public virtual T Value => _value;
    }
}
