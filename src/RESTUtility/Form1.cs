using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RESTUtility
{
	public partial class Form1 : Form
	{
		private readonly BindingList<ContentType> _contentTypeList;
		private BindingList<RequestHeaders> _headers = new BindingList<RequestHeaders>();

		public Form1()
		{
			InitializeComponent();
			_contentTypeList = new BindingList<ContentType>();

			BuildLists();
			modeSelect.SelectedItem = modeSelect.Items[0];
			protocol.SelectedItem = protocol.Items[0];
			mediaType.SelectedItem = mediaType.Items[0];
			baseUri.Clear();
			requestUri.Clear();
			requestText.Clear();
			responseText.Clear();
			responseStatusCodeLabel.BackColor = DefaultBackColor;
			headerGrid.DataSource = _headers;

			UpdateUriDisplay(null, null);
		}

		private async void goButton_MouseClick(object sender, MouseEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(baseUri.Text))
			{
				UpdateUriDisplay(null, null);
				baseUri.Focus();
			}
			else
			{
				responseText.Clear();
				await RunAsync();
			}
		}

		private async Task RunAsync()
		{
			try
			{
				using (var client = new HttpClient())
				{
					HttpResponseMessage response;
					var baseUriText = string.Format("{0}://{1}/", protocol.SelectedItem, CleanUri(baseUri.Text));
					var requestUriText = CleanUri(requestUri.Text);
					var requestContent = string.IsNullOrWhiteSpace(requestText.Text) ? null : requestText.Text;
					var xml = mediaType.Text.ToLower().Equals("xml");

					client.BaseAddress = new Uri(baseUriText);
					client.DefaultRequestHeaders.Clear();

					if (_headers.Count > 0)
						foreach (var header in _headers)
						{
							if (header.Key.ToLower().Equals("content-type"))
								client.DefaultRequestHeaders.Accept.Add(
									new MediaTypeWithQualityHeaderValue(header.Value));
							else
								client.DefaultRequestHeaders.Add(header.Key, header.Value);
						}

					switch (modeSelect.Text.ToUpper())
					{
						case "GET":
							response = await client.GetAsync(requestUriText);
							break;
						case "POST":
							if (!string.IsNullOrWhiteSpace(requestContent))
								response = xml
									? await client.PostAsXmlAsync(requestUriText, XElement.Parse(requestContent))
									: await client.PostAsJsonAsync(requestUriText, JObject.Parse(requestContent));
							else
								response = await client.PostAsync(requestUriText, null);
							break;
						case "PUT":
							if (!string.IsNullOrWhiteSpace(requestContent))
								response = xml
									? await client.PutAsXmlAsync(requestUriText, requestContent)
									: await client.PutAsJsonAsync(requestUriText, requestContent);
							else
								response = await client.PutAsync(requestUriText, null);
							break;
						case "DELETE":
							response = await client.DeleteAsync(requestUriText);
							break;
						default:
							response = new HttpResponseMessage();
							break;
					}

					if (response.Content == null)
						response.EnsureSuccessStatusCode();

					var content = await response.Content.ReadAsStringAsync();
					responseHeaders.Text = response.Headers.ToString();
					responseHeaders.AppendText(response.Content.Headers.ToString());

					try
					{
						responseText.Text = JObject.Parse(content).ToString();
					}
					catch
					{
						try
						{
							using (var xString = new StringWriter(new StringBuilder()))
							{
								using (var xWriter = new XmlTextWriter(xString) { Formatting = Formatting.Indented })
								{
									var xDoc = XDocument.Parse(content);
									xDoc.Save(xWriter);
								}

								responseText.Text = xString.ToString();
							}
						}
						catch
						{
							responseText.Text = content;
						}
					}
				}
			}
			catch (HttpRequestException hre)
			{
				responseText.Text = string.Format("Error: {0}", hre.Message);

				if (hre.InnerException != null)
					if (!string.IsNullOrWhiteSpace(hre.InnerException.Message))
						responseText.Text += Environment.NewLine + hre.InnerException.Message;
			}
		}

		private void ParseResponse(string response)
		{

		}

		private static string CleanUri(string uri)
		{
			if (string.IsNullOrWhiteSpace(uri)) return string.Empty;

			uri = uri.Replace(" ", "");
			uri = uri.Replace("https", "");
			uri = uri.Replace("http", "");
			uri = uri.Replace("://", "");
			uri = uri.Replace(":/", "");
			uri = uri.Trim('/');
			uri = uri.Replace("\"", "");
			uri = uri.Replace("//", "/");

			return uri;
		}

		private void UpdateUriDisplay(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(baseUri.Text))
				uriDisplay.Text = string.IsNullOrWhiteSpace(requestUri.Text)
					? "Please enter a Base Uri and Request Uri above"
					: "Please enter a Base Uri above";
			else
			{
				var cleanBase = CleanUri(baseUri.Text);
				var cleanRequest = CleanUri(requestUri.Text);
				uriDisplay.Text = string.Format("{0}://{1}/{2}", protocol.SelectedItem.ToString().ToLower(), cleanBase,
					cleanRequest);
			}
		}

		private void mediaType_SelectedIndexChanged(object sender, EventArgs e)
		{
			IList<RequestHeaders> reqHeaders = new List<RequestHeaders>();

			if (_headers != null)
				foreach (var reqHeader in _headers)
					if (!reqHeader.Key.ToLower().Equals("content-type"))
						reqHeaders.Add(reqHeader);

			reqHeaders.Add(new RequestHeaders("Content-Type", mediaType.SelectedValue.ToString()));

			_headers = new BindingList<RequestHeaders>(reqHeaders.OrderBy(h => h.Key).ToList());
			headerGrid.DataSource = _headers;
		}

		private void BuildLists()
		{
			_contentTypeList.Add(new ContentType { Key = "JSON", Value = "application/json" });
			_contentTypeList.Add(new ContentType { Key = "XML", Value = "application/xml" });
			mediaType.DisplayMember = "Key";
			mediaType.ValueMember = "Value";
			mediaType.DataSource = _contentTypeList;
		}
	}
}