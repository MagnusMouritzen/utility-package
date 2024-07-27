using System;
using System.Collections.Generic;
using UnityEngine;

namespace OK.Utility {
    [Serializable]
    public class Selection<T> {
        [SerializeField] private SelectionOption<T>[] options;

        private SelectionOption<T> _lastChosen;

        public T GetOne(float lastChosenFactor = 1f) {
            List<float> chances = new();
            foreach (SelectionOption<T> option in options) {
                if (_lastChosen == option) chances.Add(option.relativeChance * lastChosenFactor);
                else chances.Add(option.relativeChance);
            }

            SelectionOption<T> chosen = options[RandomRatio.RandomRatioSelection(chances)];
            _lastChosen = chosen;
            return chosen.option;
        }
    }
}