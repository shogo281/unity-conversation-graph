using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KConversation
{
	using static Conversation;

	public class RootNodeOperation : NodeOperation
	{
		public RootNodeOperation( Conversation conversation, NodeBase node, CompleteCallback onComplete, DisposeCallback onDispose ) : base( conversation, node, onComplete, onDispose )
		{
		}

		protected override void OnUpdate( float dt )
		{
			base.OnUpdate( dt );
			Complete();
		}
	}
}
