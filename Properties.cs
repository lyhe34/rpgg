using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPGG
{
	public class Properties
	{
		private Dictionary<string, object> items = new();

		public void Set(string key, object value)
		{
			if (items.ContainsKey(key))
			{
				items[key] = value;
			}
			else
			{
				items.Add(key, value);
			}
		}

		public object Get(string key)
		{
			if (items.ContainsKey(key))
			{
				return items[key];
			}
			else
			{
				return null;
			}
		}

		public T Get<T>(string key)
		{
			if (items.ContainsKey(key))
			{
				return (T)items[key];
			}
			else
			{
				return default;
			}
		}

		public bool Get<T>(string key, out T result)
		{
			if (items.ContainsKey(key))
			{
				try
				{
					result = (T)items[key];
				}
				catch (InvalidCastException e)
				{
					result = default;
					Debug.LogException(e);
				}
				return true;
			}
			else
			{
				result = default;
				return false;
			}
		}
	}
}
