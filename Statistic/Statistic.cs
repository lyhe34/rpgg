using System.Collections.Generic;
using UnityEngine;

namespace RPGG
{
	public abstract class Statistic
	{
		public Properties properties = new();

		protected float value;
		public float Value { get => value; }

		public bool isSigned = false;

		public Statistic minimum;
		public Statistic maximum;

		public PriorityList<Alter> alters = new();

		public StatisticsManager manager;

		public List<StatisticModification> timedModifications = new();

		public Reaction<StatisticModification> OnModified = new();
		public Reaction<StatisticModification> OnIncreased = new();
		public Reaction<StatisticModification> OnDecreased = new();
		public Reaction<StatisticModification> OnDepleted = new();
		public Reaction<StatisticModification> OnRepleted = new();

		public ConditionsManager<StatisticModification> preCalculConditions = new();
		public ConditionsManager<StatisticModification> postCalculConditions = new();

		public float Missing
		{
			get
			{
				if (minimum == null && maximum == null)
				{
					return 0;
				}

				return maximum.Value - Value;
			}
		}

		public float MissingPercentage
		{
			get
			{
				if (minimum == null && maximum == null)
				{
					return 0;
				}

				return 100 - Percent;
			}
		}

		public float Percent
		{
			get
			{
				if (minimum == null && maximum == null)
				{
					return 0;
				}

				return (Value + Mathf.Abs(minimum.Value)) / (maximum.value + Mathf.Abs(minimum.value)) * 100;
			}
		}

		public Statistic(StatisticsManager manager = null)
		{
			this.manager = manager;
			if(manager) manager.statistics.Add(this);
		}

		/// <summary>
		/// Performs the modification calcul, with all alters from <see cref="StatisticModifier.alters"/> and then <see cref="alters"/>
		/// </summary>
		/// <param name="modification"></param>
		protected void Alter(StatisticModification modification)
		{
			foreach (var alter in modification.modifier.GetAlters().Items)
			{
				float alterAmount = alter.Amount(modification);

				modification.amount += alterAmount;

				value += alterAmount;
			}

			modification.unalteredAmount = modification.amount;

			PriorityList<Alter> alters = new();

			alters.Concat(this.alters);
			alters.Concat(manager.alters);

			foreach (var alter in alters.Items)
			{
				float alterAmount = alter.Amount(modification);

				modification.amount += alterAmount;

				value += alterAmount;
			}
		}

		/// <summary>
		/// Limit the value between <see cref="minimum"/> and <see cref="maximum"/>./>
		/// </summary>
		/// <param name="modification"></param>
		protected void ClampValue(StatisticModification modification)
		{
			float valueBeforeClamp = value;

			float min = minimum == null ? Mathf.NegativeInfinity : minimum.Value;
			float max = maximum == null ? Mathf.Infinity : maximum.Value;

			value = Mathf.Clamp(value, min, max);

			modification.amount -= valueBeforeClamp - value;
		}

		/// <summary>
		/// Calls the appropriate reactions depending on <paramref name="modification"/> amount and <see cref="Value"/>
		/// </summary>
		/// <param name="modification"></param>
		protected void React(StatisticModification modification)
		{
			if (modification.amount != 0)
			{
				OnModified.Execute(modification);

				if (modification.amount > 0)
				{
					OnIncreased.Execute(modification);
				}
				else if (modification.amount < 0)
				{
					OnDecreased.Execute(modification);
				}

				if (Value == minimum?.Value)
				{
					OnDepleted.Execute(modification);
				}
				else if (Value == maximum?.Value)
				{
					OnRepleted.Execute(modification);
				}
			}
		}
	}
}
