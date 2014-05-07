using System;
using NUnit.Framework;
using System.Net;

namespace HttpRequestMono.Tests
{
	[TestFixture]
	public class ProxyTests
	{
		[Test]
		public void HttpRequestThroughProxy ()
		{
			string url = "http://www.nuet.org/api/v2";

			var request = WebRequest.Create(url);

			WebException webEx = null;
			try {
				request.GetResponse ();
			} catch (WebException ex) {
				webEx = ex;
			}

			var response = webEx.Response as HttpWebResponse;
			Assert.AreEqual (WebExceptionStatus.ProtocolError, webEx.Status);
			Assert.IsNotNull (response);
			Assert.AreEqual (HttpStatusCode.ProxyAuthenticationRequired, response.StatusCode);
		}

		[Test]
		/// <summary>
		/// Should be treated the same as an unsecure http request.
		/// </summary>
		public void HttpsRequestThroughProxy ()
		{
			string url = "https://www.nuet.org/api/v2";

			var request = WebRequest.Create(url);

			WebException webEx = null;
			try {
				request.GetResponse ();
			} catch (WebException ex) {
				webEx = ex;
			}

			var response = webEx.Response as HttpWebResponse;
			Assert.AreEqual (WebExceptionStatus.ProtocolError, webEx.Status);
			Assert.IsNotNull (response);
			Assert.AreEqual (HttpStatusCode.ProxyAuthenticationRequired, response.StatusCode);
		}
	}
}

