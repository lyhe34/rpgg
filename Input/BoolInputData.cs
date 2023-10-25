using UnityEngine.InputSystem;

namespace RPGG
{
	public class BoolInputData : InputData<bool>
	{
		public override bool IsDown(InputValue inputValue)
		{
			var v = inputValue.Get<float>();

			bool isDown = v != 0;

			Value = isDown;

			if (isDown) LastTriggeredValue = isDown;

			return isDown;
		}
	}
}