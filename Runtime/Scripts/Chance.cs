using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OK.Utility {
    [Serializable]
    public class Chance
    {
        [SerializeField] private int chance;
        
        public bool Try()
        {
            return Random.Range(0, 100) < chance;
        }

        public int GetChance() => chance;
    }
}
