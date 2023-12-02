namespace DataLoader;

public record ColorSet(int Red, int Green, int Blue) { }

public record GameSets(int GameNumber, List<ColorSet> Sets) { }
