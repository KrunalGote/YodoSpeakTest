using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.IO;

using TestStack.White.UIItems;

namespace YodoTest
{
    [TestClass]
    public class UITest
    {
       
        
        //UITest()
        //{
            
        //    var applicationDirectory = TestContext.TestDeploymentDir;
        //    //var applicationPath = Path.Combine(Server, "foo.exe");
        //    //Application application = Application.Launch(applicationPath);
        //    //Window window = application.GetWindow("bar", InitializeOption.NoCache);
        //    string n = "a";
        //}
        [TestMethod]
        public void Test_TextBox_IsEmpty()
        {
            var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var applicationPath = Path.Combine(applicationDirectory, "TestYodoConvertor.exe");
            using (var application = TestStack.White.Application.Launch(applicationPath))
            {
                string textboxChar = string.Empty;
                                var testYodo = application.GetWindow("Yodo Speak Convertor", TestStack.White.Factory.InitializeOption.NoCache);
                var btnConvert = testYodo.Get<Button>("btnConvert");
                var txtInput = testYodo.Get<TextBox>("txtInput");
                txtInput.Text = string.Empty;
                Assert.AreEqual(textboxChar, txtInput.Text);
                application.Close();
            }
        }

        [TestMethod]
        public void Test_TextBox_IsNotEmpty_And_Button_Is_Enable()
        {
            var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var applicationPath = Path.Combine(applicationDirectory, "TestYodoConvertor.exe");
            using (var application = TestStack.White.Application.Launch(applicationPath))
            {
                string textboxChar = "Hi Yodo";
                bool isEnable = true;
                var testYodo = application.GetWindow("Yodo Speak Convertor", TestStack.White.Factory.InitializeOption.NoCache);
                var btnConvert = testYodo.Get<Button>("btnConvert");
                var txtInput = testYodo.Get<TextBox>("txtInput");
                txtInput.Text = "Hi Yodo";
                Assert.AreEqual(textboxChar, txtInput.Text);
                Assert.AreEqual(isEnable, btnConvert.Enabled);
                application.Close();
            }
        }

        [TestMethod]
        public void Test_Yodo_Speak()
        {
            var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var applicationPath = Path.Combine(applicationDirectory, "TestYodoConvertor.exe");
            using (var application = TestStack.White.Application.Launch(applicationPath))
            {
                string result = "Sorry. Yodo service is down.";
               
                var testYodo = application.GetWindow("Yodo Speak Convertor", TestStack.White.Factory.InitializeOption.NoCache);
                var btnConvert = testYodo.Get<Button>("btnConvert");
                var txtInput = testYodo.Get<TextBox>("txtInput");
                var lblOutput = testYodo.Get<Label>("lblOutput");
                txtInput.Text = "i am going to home";
                btnConvert.Click();
                do { }
                while (string.IsNullOrEmpty(lblOutput.Text));
                Assert.AreNotEqual(result, lblOutput.Text);
                application.Close();
            }
        }
    }
}
