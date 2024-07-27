using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace OK.Utility {
    [Serializable]
    public class MinMaxFloat {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Random() {
            return UnityEngine.Random.Range(min, max);
        }

        public float GetChanceToBeAbove(float target) {
            if (target < min) return 1f;
            if (target >= max) return 0f;
            return (max - target) / (max - min);
        }

        public int GetPercentageChanceToBeAbove(float target) {
            float chance = GetChanceToBeAbove(target);
            return (int)(chance * 100f);
        }

        public static MinMaxFloat operator +(MinMaxFloat a) => a;

        public static MinMaxFloat operator -(MinMaxFloat a) => new() { min = -a.min, max = -a.max };

        public static MinMaxFloat operator +(MinMaxFloat a, MinMaxFloat b) =>
            new() { min = a.min + b.min, max = a.max + b.max };

        public static MinMaxFloat operator -(MinMaxFloat a, MinMaxFloat b) => a + (-b);

        public static MinMaxFloat operator *(MinMaxFloat a, float f) => new() { min = a.min * f, max = a.max * f };

        public static MinMaxFloat operator /(MinMaxFloat a, float f) => new() { min = a.min / f, max = a.max / f };

        public static MinMaxFloat operator *(MinMaxFloat a, MinMaxFloat b) =>
            new() { min = a.min * b.min, max = a.max * b.max };

        public static MinMaxFloat operator /(MinMaxFloat a, MinMaxFloat b) =>
            new() { min = a.min / b.min, max = a.max / b.max };
    }
}