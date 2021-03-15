using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using System;
using KConversation;
using UnityEditor;

namespace KConversationEditor
{
	[CustomNodeGraphEditor( typeof( ConversationGraph ) )]
	public class ConversationGraphEditor : NodeGraphEditor
	{
		private ConversationGraph Target => target as ConversationGraph;

		public override string GetNodeMenuName( Type type )
		{
			if( typeof( ConversationNodeBase ).IsAssignableFrom( type ) )
			{
				return type.Name;
			}

			return null;
		}

		public override void OnOpen()
		{
			base.OnOpen();

			if( Target.nodes.Count == 0 )
			{
				CreateNode( typeof( ConversationNodeBase ), Vector2.zero );
			}
		}
	}
}
