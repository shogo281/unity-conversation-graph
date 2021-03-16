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
			if( type == typeof( RootNode ) )
			{
				return null;
			}

			if( typeof( NodeBase ).IsAssignableFrom( type ) )
			{
				return type.Name;
			}

			return null;
		}

		public override void OnOpen()
		{
			base.OnOpen();
		}
	}
}
