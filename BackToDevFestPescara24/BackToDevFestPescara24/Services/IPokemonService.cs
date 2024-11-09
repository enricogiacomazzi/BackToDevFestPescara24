using System.ComponentModel;
using BackToDevFestPescara24.Models;

namespace BackToDevFestPescara24.Services;

public interface IPokemonService : INotifyPropertyChanged
{
    PokemonModel[] Pokemon { get; }
    Task GetPokemon();
    Task AddLike(int id);
}