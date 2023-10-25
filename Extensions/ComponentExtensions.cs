using UnityEngine;

public static class ComponentExtensions
{
	/// <summary>
	/// First check if the <paramref name="component"/>'s <see cref="GameObject"/> has component <typeparamref name="T"/>, if not, add it.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="component"></param>
	/// <returns></returns>
	public static T GetOrAddComponent<T>(this Component component) where T : Component
	{
		T c = component.GetComponent<T>();

		if (c == null)
		{
			c = component.gameObject.AddComponent<T>();
		}

		return c;
	}
}
