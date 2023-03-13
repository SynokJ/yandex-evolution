public static class EvolutionListener
{
    private static System.Collections.Generic.List<IEvolutionable> _evolutionables =
        new System.Collections.Generic.List<IEvolutionable>();

    public static void OnListen(IEvolutionable evolutionable)
    {
        if (!_evolutionables.Contains(evolutionable))
            _evolutionables.Add(evolutionable);
    }

    public static void OnUnListen(IEvolutionable evolutionable)
    {
        if (_evolutionables.Contains(evolutionable))
            _evolutionables.Remove(evolutionable);
    }

    public static void OnEvolute()
    {
        for (int i = 0; i < _evolutionables.Count; ++i)
            _evolutionables[i].OnEvoluted();
    }
}
