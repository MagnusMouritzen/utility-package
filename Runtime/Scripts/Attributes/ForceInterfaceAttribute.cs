using System;
using UnityEngine;

namespace OK.Utility {
    public class ForceInterfaceAttribute : PropertyAttribute {
        public readonly Type interfaceType;

        public ForceInterfaceAttribute(Type interfaceType) {
            this.interfaceType = interfaceType;
        }
    }
}
