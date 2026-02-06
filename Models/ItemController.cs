using System;
using System.Linq;

using ToDo.Models;
public class ItemController
{
    public List<Item> Itens = new();
    public List<Item> ItensToday()
    {
        return Itens.Where(i => i.Date == DateTime.Today).ToList();
    }

    public List<Item> ItensTomorrow()
    {
        return Itens.Where(i => i.Date == DateTime.Today.AddDays(1)).ToList();
    }
    public Item newItem = new();

    public void OrderList()
    {
        Itens = Itens.OrderBy(i => i.IsFinished).ThenBy(i => i.Date).ToList();
    }
    public void AddItem()
    {
        Itens.Add(new Item
        {
            Name = newItem.Name,
            Description = newItem.Description,
            Date = newItem.Date,
            Hour = newItem.Hour
        });

        OrderList();

        newItem = new(); // limpa o formulário
    }
}
