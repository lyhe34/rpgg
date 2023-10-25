using System.Collections.Generic;
using System.Linq;

namespace RPGG
{
	/// <summary>
	/// Use this for statistics like Armor, Intelligence, Dextirity, Endurance...
	/// Modifiable by adding <see cref="StatisticModifier"/> that persist until removed.
	/// </summary>
	public class Characteristic : Statistic
	{
		public override float Value 
		{
			get
			{
				if (!isCalculating)
				{
					CalculateValue();
				}

				return value;
			}
		}

		public Statistic baseValue;

		/// <summary>
		/// The currents <see cref="StatisticModifier"/> added to this characteristic, that will define the final value of the characteristic.
		/// </summary>
		public SortedList<int, StatisticModification> activeModifications = new();

		public Reaction<StatisticModification> OnModifierAdded = new();
		public Reaction<StatisticModification> OnModifierRemoved = new();

		// Prevent a infinite loop while calculating the final value.
		private bool isCalculating = false;

		public Characteristic(StatisticsManager manager) : base(manager)
		{

		}

		public Characteristic(float baseValue, StatisticsManager manager = null) : base(manager)
		{
			this.baseValue = new Resource(baseValue, manager);
		}

		public Characteristic(StatisticsManager manager, Statistic baseValue) : base(manager)
		{
			this.baseValue = baseValue;
		}

		public void AddModifier(StatisticModifier modifier, int priority = 0)
		{
			var existingModification = activeModifications.Values.FirstOrDefault(m => m.modifier == modifier);

			if (existingModification != null)
			{
				preCalculConditions.CheckConditions(existingModification);

				if (modifier.isTimed)
				{
					if (existingModification.timer == null)
					{
						Timer timer = new(modifier.duration);
						existingModification.timer = timer;
						manager.AddTimedModification(existingModification);
					}
					else
					{
						existingModification.timer.currentTime = 0;
					}
				}
				if (modifier.isStackable)
				{
					if (existingModification.stacks == null)
					{
						Stacks stacks = new(modifier.maximumStacks);
						existingModification.stacks = stacks;
					}
					else
					{
						existingModification.stacks.AppendStack();
					}
				}
			}
			else
			{
				StatisticModification newModification = new StatisticModification(this, modifier);

				preCalculConditions.CheckConditions(newModification);

				if (modifier.isStackable)
				{
					newModification.stacks = new Stacks(modifier.maximumStacks);
				}
				if (modifier.isTimed)
				{
					newModification.timer = new Timer(modifier.duration);

					newModification.timer.OnTimerEnd.OnExecuted += () => RemoveModifier(modifier);

					manager.AddTimedModification(newModification);
				}

				activeModifications.Add(priority, newModification);

				OnModifierAdded.Execute(newModification);
			}

			StatisticModification modification = CalculateValue();
			
			modification.modifier = modifier;

			React(modification);
		}

		public void RemoveModifier(StatisticModifier modifier)
		{
			var existingModification = activeModifications.Values.FirstOrDefault(m => m.modifier == modifier);

			if (existingModification != null)
			{
				activeModifications.Values.Remove(existingModification);

				StatisticModification modification = CalculateValue();
				modification.modifier = modifier;

				React(modification);
				OnModifierRemoved.Execute(modification);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public StatisticModification CalculateValue()
		{
			isCalculating = true;

			value = baseValue != null ? baseValue.Value : 0;

			StatisticModification totalModification = new StatisticModification(this);

			foreach (var activeModification in activeModifications.Values)
			{
				StatisticModification modification = new StatisticModification(this, activeModification.modifier, activeModification.stacks, activeModification.timer);

				Alter(modification);

				totalModification.amount += modification.amount;
			}

			ClampValue(totalModification);

			isCalculating = false;

			return totalModification;
		}
	}
}
