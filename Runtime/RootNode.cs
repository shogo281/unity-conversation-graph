using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace KConversation
{
	/// <summary>
	/// �e�m�[�h
	/// </summary>
	public class RootNode : NodeBase
	{
		[Output( backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override ), SerializeField] private NodeBase output = null;

		public override object GetValue( NodePort port )
		{
			return output;
		}

		private void Reset()
		{
			output = this;
		}
	}
}
