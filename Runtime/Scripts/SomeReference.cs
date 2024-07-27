using System;
using UnityEngine;

namespace OK.Utility {
    [Serializable]
    public class SomeReference<T> : Some<T> {
        [SerializeReference, SubclassSelector] [SerializeField] private T _value;

        public override T Value => _value;
    }
}
