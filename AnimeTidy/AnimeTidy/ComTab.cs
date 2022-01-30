using System.Windows.Forms;

namespace AnimeTidy
{
	public class ComTab : UserControl
	{
		public virtual void HandleNew() { }

		public virtual void HandleOpen() { }

		public virtual void HandleSave() { }

		public virtual void HandleAdd() { }

		public virtual void HandleModify() { }

		public virtual void HandleDuplicate() { }

		public virtual void HandleDelete() { }

		public virtual void HandleUndo() { }

		public virtual void HandleRefresh() { }

		public virtual void HandleFind(Form ffm) { }

		public virtual void HandleGroup() { }

		public virtual void HandleOverlay() { }

		public virtual void HandleBackup() { }

		public virtual bool PerformClosing() { return true; }
	}
}
