﻿// Ignore Spelling: Ctrl Prefs Ctrls

using System.Linq;

namespace BestChat.Platform.Prefs.Ctrls
{
	using BestChat.Platform.Prefs.Data;
	using Util.Ext;

	public sealed class VisualPrefsTreeData : System.Windows.DependencyObject
	{
		#region Constructors & Deconstructors
			public VisualPrefsTreeData(Data.AbstractMgr mgr)
			{
				if(!mapDataMgrToCtrlType.ContainsKey(typeof(Data.AbstractMgr)))
					throw new System.ArgumentException("Unable to construct the prefs manager to control relationship as no control type was " +
						"specified.", nameof(mgr));

				Mgr = mgr;

				System.Func<AbstractMgr, VisualPrefsTabCtrl> funcCtrlMaker = mapDataMgrToCtrlType[mgr.GetType()];
				if(funcCtrlMaker != null)
					UI = funcCtrlMaker(mgr);
				UI ??= new PrefsGenericTreeListerPage()
					{
						Children = Children,
					};

				foreach(Data.AbstractChildMgr cmgrCur in mgr.ChildMgrByName.Where(cmgrCur => !UI.HandlesChildMgrsOfType
						.Contains(cmgrCur.GetType())))
					ocChildren.Add(new(cmgrCur));
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private static readonly System.Collections.Generic.Dictionary<System.Type, System.Func<AbstractMgr, VisualPrefsTabCtrl>>
				mapDataMgrToCtrlType = [];

			private readonly System.Collections.ObjectModel.ObservableCollection<VisualPrefsTreeData> ocChildren =
				[];
		#endregion

		#region Properties
			public Data.AbstractMgr Mgr
			{
				get;

				private init;
			}

			public VisualPrefsTabCtrl UI
			{
				get;

				private init;
			}

			public System.Collections.Generic.IReadOnlyList<VisualPrefsTreeData> Children => ocChildren;
		#endregion

		#region Methods
			public static void RegisterDataEditorCtrlType(in System.Type typeOfMgr, in System.Func<AbstractMgr, VisualPrefsTabCtrl>
				funcCtrlMaker)
			{
				if(!typeOfMgr.IsDerivedFrom(typeof(Data.AbstractMgr)))
					throw new System.ArgumentException("When calling BestChat.Platform.TreeData.VisualTreeData.RegisterDataEditorCtrlType, the" +
						$" type specified in {typeOfMgr} must be a BestChat preference manager, either child or main.",
						nameof(typeOfMgr));

				if(mapDataMgrToCtrlType.ContainsKey(typeOfMgr))
					throw new System.ArgumentException("Chat.Platform.TreeData.VisualTreeData.RegisterDataEditorCtrlType was already called " +
						"with a manager type that was already in the system.", nameof(typeOfMgr));

				mapDataMgrToCtrlType[typeOfMgr] = funcCtrlMaker ?? throw new System.ArgumentNullException("The function passed to BestChat" +
					".Platform.TreeData.VisualTreeData.RegisterDataEditorType in was null", nameof(funcCtrlMaker));
			}
		#endregion

		#region Event Handlers
		#endregion
	}
}