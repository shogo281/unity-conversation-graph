using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace KConversation
{
	/// <summary>
	/// テキスト表示用ノード
	/// </summary>
	public class TextNode : NodeBase
	{
		[SerializeField, Multiline] private string text = "";
		[Input( backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override ), SerializeReference] private NodeBase input = null;
		[Output( backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override ), SerializeReference] private NodeBase output = null;

		public NodeBase Input => input;

		public NodeBase Output => output;

		public override void OnCreateConnection( NodePort from, NodePort to )
		{
			if( from.node is NodeBase nodeBase )
			{
				input = nodeBase;
			}

			base.OnCreateConnection( from, to );
		}

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
