using UnityEngine;

public static class TokenManager
{
    static string playerName = "hermenegildo";
    static string[] places = { "pueblo paleta", "ciudad verde", "isla canela", "ruta 1" };
    static string[] pokemons = { "pikachu", "charmander", "bulbasaur", "squirtle", "eevee" };
    static string[] items = { "poké ball", "super ball", "poción", "antídoto", "cuerda huida" };
    static string[] medals = { "medalla trueno", "medalla volcán", "medalla cascada", "medalla tierra" };

    public static string GetPlayerName() => playerName;
    public static string GetRandomPlace() => places[Random.Range(0, places.Length)];
    public static string GetRandomPokemon() => pokemons[Random.Range(0, pokemons.Length)];
    public static string GetRandomItem() => items[Random.Range(0, items.Length)];
    public static string GetRandomMedal() => medals[Random.Range(0, medals.Length)];

    public static void SetPlayerName(string name)
    {
        playerName = name;
    }
}