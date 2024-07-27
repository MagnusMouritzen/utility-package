using System;

namespace OK.Utility {
    [Serializable]
    public class SelectionOption<T> {
        public T option;
        public float relativeChance;
    }
}
