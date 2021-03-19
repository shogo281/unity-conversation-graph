using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KConversation
{
	/// <summary>
	/// ëIëéàÉmÅ[Éh
	/// </summary>
	public class TextOptionsNode : NodeBase
	{
		[Serializable]
		private class Option
		{
			[SerializeField] public string text = "";
		}

		[SerializeField] private Option[] optionArray = { };
		[Input( backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override ), SerializeField] private NodeBase input = null;
		[Output( backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple ), SerializeField] private NodeBase output = null;
	}
}
