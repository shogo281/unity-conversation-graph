using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using System;
using KConversation;

namespace KConversationEditor
{
	[CustomNodeGraphEditor( typeof( ConversationGraph ) )]
	public class ConversationGraphEditor : NodeGraphEditor
	{
		public override string GetNodeMenuName( Type type )
		{
			if( typeof( ConversationNode ).IsAssignableFrom( type ) )
			{
				return type.Name;
			}

			return null;
		}
	}
}
