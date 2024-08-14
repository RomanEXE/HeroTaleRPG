public static class RandomChance
{
    public static bool Random(int chance)
    {
        int randomNumber = UnityEngine.Random.Range(0, 100);

        return randomNumber <= chance;
    }
}