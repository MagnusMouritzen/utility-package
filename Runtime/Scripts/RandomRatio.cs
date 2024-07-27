using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OK.Utility {
    public static class RandomRatio
    {
        public static bool RandomRatioChance(float succeedChance, float failChance)
        {
            return Random.Range(0f, succeedChance + failChance) < succeedChance;
        }

        public static int RandomRatioSelection(IList<float> chances)
        {
            float cumChance = 0f;
            foreach (float chance in chances)
            {
                cumChance += chance;
            }
            float random = Random.Range(0f, cumChance);
            for (int i = 0; i < chances.Count; i++)
            {
                if (random <= chances[i]) return i;
                random -= chances[i];
            }
            Debug.LogError("No option was selected. " + chances);
            return 0;
        }
    }
}
