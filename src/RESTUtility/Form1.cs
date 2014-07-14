using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace RESTUtility
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			modeSelect.SelectedItem = modeSelect.Items[0];
			protocol.SelectedItem = protocol.Items[0];
			mediaType.SelectedItem = mediaType.Items[0];
			baseUri.Clear();
			requestUri.Clear();
			requestText.Clear();
			responseText.Clear();

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
					var xml = mediaType.SelectedItem.ToString().ToLower().Equals("xml");
					var raw = mediaType.SelectedItem.ToString().ToLower().Equals("raw");

					client.BaseAddress = new Uri(baseUriText);
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue(xml ? "text/xml" : "application/json"));


					switch (modeSelect.SelectedItem.ToString().ToUpper())
					{
						case "GET":
							response = await client.GetAsync(requestUriText);
							break;
						case "POST":
							if (!string.IsNullOrWhiteSpace(requestContent))
								if (!raw)
									response = xml
										? await client.PostAsXmlAsync(requestUriText, XElement.Parse(requestContent))
										: await client.PostAsJsonAsync(requestUriText, JObject.Parse(requestContent));
								else
									response = await client.PostAsync(requestUriText, new StringContent(requestContent));
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

					response.EnsureSuccessStatusCode();

					var content = await response.Content.ReadAsStringAsync();
					if (response.Content.Headers.ContentType.MediaType.Equals("application/xml"))
					{
						
						using (var xString = new StringWriter(new StringBuilder()))
						{
							using (var xWriter = new XmlTextWriter(xString) {Formatting = Formatting.Indented})
							{
								var xDoc = XDocument.Parse(content);
								xDoc.Save(xWriter);
							}

							responseText.Text = xString.ToString();
						}
					}
					else if (response.Content.Headers.ContentType.MediaType.Equals("application/json"))
						responseText.Text = JObject.Parse(content).ToString();
					else
						responseText.Text = content;
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

		private static string CleanUri(string uri)
		{
			if (string.IsNullOrWhiteSpace(uri)) return string.Empty;

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
	}
}
