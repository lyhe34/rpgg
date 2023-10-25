using UnityEngine;
using UnityEngine.InputSystem;

namespace RPGG
{
	public class Vector2InputData : InputData<Vector2>
	{
		public override bool IsDown(InputValue inputValue)
		{
			var v = inputValue.Get<Vector2>();

			Value = v;

			return v != Vector2.zero;
		}
	}
}