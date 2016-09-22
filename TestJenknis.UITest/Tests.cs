using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestJenknis.UITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		//[Test]
		//public void AppLaunches()
		//{
		//	app.Screenshot("First screen.");
		//}

		[Test]
		public void Test_Click_Button_Twice()
		{
			Func<AppQuery, AppQuery> button = c => c.Button("myButton");

			app.Tap(button);
			app.Tap(button);
			AppResult[] results = app.Query(button);
			app.Screenshot("Button clicked twice.");

			Assert.AreEqual("2 clicks!", results[0].Text ?? results[0].Label);
		}
	}
}
