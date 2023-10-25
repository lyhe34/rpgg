using System.Collections.Generic;
using RPGG;

namespace RPGG
{
	public class Inventory
	{
		private List<Item> items = new();

		public Statistic capacity;

		public Reaction<Item> OnItemAdd;
		public Reaction<Item> OnItemRemove;

		public void AddItem(Item item)
		{
			items.Add(item);
			item.inventory = this;

			item.OnInventoryAdd.Execute();
			OnItemAdd.Execute(item);
		}

		public void RemoveItem(Item item)
		{
			if (items.Remove(item))
			{
				item.inventory = null;

				item.OnInventoryRemove.Execute();
				OnItemRemove.Execute(item);
			}
		}
	}
}
