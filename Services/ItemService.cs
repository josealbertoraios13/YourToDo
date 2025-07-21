using System;

using Blazored.LocalStorage;
using ToDo.Models;

namespace ToDo.Services;
public class ItemService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "Itens";

    public ItemService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return await _localStorage.GetItemAsync<List<Item>>(StorageKey) ?? new List<Item>();
    }

    public async Task SaveItensAsync(List<Item> itens)
    {
        await _localStorage.SetItemAsync(StorageKey, itens);
    }
}