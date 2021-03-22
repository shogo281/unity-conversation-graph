using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KConversation
{
	public class Conversation : IDisposable
	{
		/// <summary>
		/// �ʏ�̉�b�̃R�[���o�b�N(�I���Ȃ�)
		/// </summary>
		/// <param name="text"></param>
		public delegate void DefaultConversationCallback( string text );
		public delegate void CompleteCallback();
		public delegate void DisposeCallback();
		private ConversationGraph graph = null;
		private bool isDisposed = false;
		private NodeBase current = null;
		private NodeOperation nodeOperation = null;
		private bool isComplete = false;
		private DefaultConversationCallback onDefaultConversationCallback = null;

		public bool IsAuto
		{
			get;
			set;
		}

		public bool IsPLaying
		{
			get;
			private set;
		} = false;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="graph"></param>
		public Conversation( ConversationGraph graph )
		{
			this.graph = graph;
			isDisposed = false;
			current = null;
			IsPLaying = false;
			isComplete = false;
		}

		/// <summary>
		/// �Đ�����
		/// </summary>
		public void Play( DefaultConversationCallback onDefaultConversation = null )
		{
			if( isDisposed == true )
			{
				return;
			}

			if( IsPLaying == true )
			{
				return;
			}

			IsPLaying = true;

			current = graph.RootNode;
			onDefaultConversationCallback = onDefaultConversation;
			nodeOperation = current.CreateNodeOperation( this, onDefaultConversationCallback, OnComplete, OnDispose );
		}

		/// <summary>
		/// �X�V
		/// </summary>
		/// <param name="dt"></param>
		public void Update( float dt )
		{
			if( isDisposed == true )
			{
				return;
			}

			if( IsPLaying == false )
			{
				return;
			}

			nodeOperation.Update( dt );

			if( isComplete == true )
			{
				MoveNextNode();
				isComplete = false;
			}
		}

		/// <summary>
		/// �j��
		/// </summary>
		public void Dispose()
		{
			if( isDisposed == true )
			{
				return;
			}

			if( IsPLaying == true )
			{
				Stop();
			}

			onDefaultConversationCallback = null;
			isDisposed = true;
			graph = null;
		}

		private void OnComplete()
		{
			isComplete = true;
		}

		private void OnDispose()
		{

		}

		private void MoveNextNode()
		{
			if( current.MoveNext() != null )
			{
				current = current.MoveNext();
				nodeOperation = current.CreateNodeOperation( this, onDefaultConversationCallback, OnComplete, OnDispose );
			}
			else
			{
				IsPLaying = false;
			}
		}

		private void Stop()
		{
			IsPLaying = false;
		}

		/// <summary>
		/// ���̃e�L�X�g��\������
		/// </summary>
		public void MoveNextText()
		{
			if( IsAuto == true )
			{
				return;
			}
		}
	}
}
