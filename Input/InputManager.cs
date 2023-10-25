using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPGG
{
	public class InputManager : MonoBehaviour
	{
		private List<InputData> inputDatas = new List<InputData>();

		public static FloatInputData Horizontal { get; private set; } = new FloatInputData();

		public static FloatInputData Vertical { get; private set; } = new FloatInputData();

		public static Vector2InputData Aim { get; private set; } = new Vector2InputData();

		public static FloatInputData Jump { get; private set; } = new FloatInputData();

		public static InputData Fire { get; private set; } = new InputData();

		public static InputData Dash { get; private set; } = new InputData();

		public static InputData Switch { get; private set; } = new InputData();

		public static InputData Interact { get; private set; } = new InputData();

		public static InputData Spell1 { get; private set; }

		public static InputData Spell2 { get; private set; }

		public static InputData Spell3 { get; private set; }

		public static InputData Spell4 { get; private set; }

		private void Awake()
		{
			inputDatas.Add(Horizontal);
			inputDatas.Add(Vertical);
			inputDatas.Add(Aim);
			inputDatas.Add(Jump);
			inputDatas.Add(Fire);
			inputDatas.Add(Dash);
			inputDatas.Add(Switch);
			inputDatas.Add(Interact);
		}

		private void LateUpdate()
		{
			foreach (var inputData in inputDatas)
			{
				inputData.Reset();
			}
		}

		private void OnHorizontal(InputValue inputValue)
		{
			Horizontal.Update(inputValue);
		}

		private void OnJump(InputValue inputValue)
		{
			Jump.Update(inputValue);
		}

		private void OnFire(InputValue inputValue)
		{
			Fire.Update(inputValue);
		}

		private void OnDash(InputValue inputValue)
		{
			Dash.Update(inputValue);
		}

		private void OnAim(InputValue inputValue)
		{
			Aim.Update(inputValue);
		}

		private void OnSwitch(InputValue inputValue)
		{
			Switch.Update(inputValue);
		}

		private void OnInteract(InputValue inputValue)
		{
			Interact.Update(inputValue);
		}

		private void OnSpell1(InputValue inputValue)
		{
			var v = inputValue.Get<float>();

		}
	}
}