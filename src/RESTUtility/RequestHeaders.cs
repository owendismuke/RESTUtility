using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RESTUtility
{
	public class RequestHeaders : INotifyPropertyChanged
	{
		public RequestHeaders(){}

		public RequestHeaders(string key, string value)
		{
			_key = key;
			_value = value;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			var temp = PropertyChanged;
			if (temp != null)
				temp(this, new PropertyChangedEventArgs(propertyName));
		}

		public string Key
		{
			get { return _key; }
			set
			{
				if (_key != null && _key.Equals(value)) return;
				_key = value;
				RaisePropertyChanged();
			}
		}

		public string Value
		{
			get { return _value; }
			set
			{
				if (_value != null && _value.Equals(value)) return;
				_value = value;
				RaisePropertyChanged();
			}
		}

		private string _key;
		private string _value;
	}
}