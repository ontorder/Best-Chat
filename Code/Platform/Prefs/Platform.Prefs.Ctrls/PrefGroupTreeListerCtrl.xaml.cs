﻿namespace BestChat.Platform.Prefs.Ctrls
{
	/// <summary>
	/// Interaction logic for PrefGroupTreeListerCtrl.xaml
	/// </summary>
	public partial class PrefGroupTreeListerCtrl : System.Windows.Controls.ItemsControl
	{
		#region Constructors & Deconstructors
			public PrefGroupTreeListerCtrl()
			{
				InitializeComponent();
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
			#region Dependency Properties
				public readonly System.Windows.DependencyProperty ChildrenProperty = System.Windows.DependencyProperty.Register(nameof(Children),
					typeof(System.Collections.Generic.IReadOnlyCollection<VisualPrefsTreeData>), typeof(PrefGroupTreeListerCtrl));
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
		#endregion

		#region Properties
			public System.Collections.Generic.IReadOnlyCollection<VisualPrefsTreeData> Children
			{
				get => (System.Collections.Generic.IReadOnlyList<VisualPrefsTreeData>)GetValue(ChildrenProperty);

				init => SetValue(ChildrenProperty, value);
			}
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}