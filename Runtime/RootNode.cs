using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using XNode;

namespace KConversation
{
	using static Conversation;

	/// <summary>
	/// êeÉmÅ[Éh
	/// </summary>
	public class RootNode : NodeBase
	{
		[Output( backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override ), SerializeField] private RootNodeData outputNodeData = null;

		public override object GetValue( NodePort port )
		{
			return outputNodeData;
		}

		public override NodeBase MoveNext()
		{
			var port = GetOutputPort( "outputNodeData" );

			return port.Connection.node as NodeBase;
		}

		public override NodeOperation CreateNodeOperation( Conversation conversation, DefaultConversationCallback onDefaultConversation, CompleteCallback onComplete, DisposeCallback onDispose )
		{
			return new RootNodeOperation( conversation, this, onComplete, onDispose );
		}
	}
}
