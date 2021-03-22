using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KConversation
{
	[Serializable]
	public class NodeData
	{
	}

	[Serializable]
	public class RootNodeData : NodeData
	{

	}

	[Serializable]
	public class TextNodeData : NodeData
	{
		[Multiline] public string[] textArray;


		public TextNodeData()
		{

		}

		public TextNodeData( TextNodeData textNodeData )
		{
			textArray = textNodeData.textArray.ToArray();
		}
	}
}
