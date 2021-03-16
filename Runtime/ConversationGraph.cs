using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace KConversation
{
	[CreateAssetMenu( fileName = "conversation_graph", menuName = "Conversation/Graph" ), RequireNode( typeof( RootNode ) )]
	public class ConversationGraph : NodeGraph
	{
	}
}
