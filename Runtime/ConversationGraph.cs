using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace KConversation
{
	[CreateAssetMenu( fileName = "conversation_graph", menuName = "Conversation/Graph" ), RequireNode( typeof( RootNode ) )]
	public class ConversationGraph : NodeGraph
	{
		[SerializeField] private RootNode rootNode = null;

		public RootNode RootNode => rootNode;

		public override Node AddNode( Type type )
		{
			var node = base.AddNode( type );

			if( node is RootNode rootNode )
			{
				this.rootNode = rootNode;
			}

			return node;
		}
	}
}
