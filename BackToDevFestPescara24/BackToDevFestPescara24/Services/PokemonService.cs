using System.ComponentModel;
using System.Runtime.CompilerServices;
using BackToDevFestPescara24.Models;

namespace BackToDevFestPescara24.Services;

public class PokemonService : IPokemonService
{
    private readonly HttpClient _httpClient;
    public PokemonModel[] Pokemon { get; private set; } = Array.Empty<PokemonModel>();
    public event PropertyChangedEventHandler? PropertyChanged;

    public PokemonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task GetPokemon()
    {
        var list = await _httpClient.GetFromJsonAsync<PokemonResult>("https://pokeapi.co/api/v2/pokemon");
        Pokemon = await Task.WhenAll(
            list.results.Select(p =>
                _httpClient.GetFromJsonAsync<PokemonModel>(p.url)
            ));
    }

    public async Task AddLike(int id)
    {
        var index = Array.FindIndex(Pokemon, x => x.id == id);
        if (index >= 0)
        {
            Pokemon[index].Likes++;
            OnPropertyChanged();
        }
    }


    
    private void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}