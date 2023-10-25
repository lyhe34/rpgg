using UnityEngine.InputSystem;

namespace RPGG
{
	public class FloatInputData : InputData<float>
	{
		public override bool IsDown(InputValue inputValue)
		{
			var v = inputValue.Get<float>();

			bool isDown = v != 0;

			Value = v;

			if (isDown) LastTriggeredValue = v;

			return isDown;
		}
	}
}