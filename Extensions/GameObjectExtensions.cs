using UnityEngine;

public static class GameObjectExtensions
{
	/// <summary>
	/// First check if the <paramref name="gameObject"/> has component <typeparamref name="T"/>, if not, add it.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="gameObject"></param>
	/// <returns></returns>
	public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		T component = gameObject.GetComponent<T>();

		if (component == null)
		{
			component = gameObject.AddComponent<T>();
		}

		return component;
	}
}
