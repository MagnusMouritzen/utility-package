using System;
using UnityEngine;

namespace OK.Utility {
    [Serializable]
    public class MinMaxInt {
        [SerializeField] private int min;
        [SerializeField] private int max;

        public int Random() {
            return UnityEngine.Random.Range(min, max + 1);
        }

        public static MinMaxInt operator +(MinMaxInt a) => a;

        public static MinMaxInt operator -(MinMaxInt a) => new() { min = -a.min, max = -a.max };

        public static MinMaxInt operator +(MinMaxInt a, MinMaxInt b) =>
            new() { min = a.min + b.min, max = a.max + b.max };

        public static MinMaxInt operator -(MinMaxInt a, MinMaxInt b) => a + (-b);

        public static MinMaxInt operator *(MinMaxInt a, int f) => new() { min = a.min * f, max = a.max * f };

        public static MinMaxInt operator /(MinMaxInt a, int f) => new() { min = a.min / f, max = a.max / f };

        public static MinMaxInt operator *(MinMaxInt a, MinMaxInt b) =>
            new() { min = a.min * b.min, max = a.max * b.max };

        public static MinMaxInt operator /(MinMaxInt a, MinMaxInt b) =>
            new() { min = a.min / b.min, max = a.max / b.max };
    }
}
