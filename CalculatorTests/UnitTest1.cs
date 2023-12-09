using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private IWebDriver driver;
        private CalculatorPage calculatorPage;

        [SetUp]
        public void Setup()
        {
            // ������������� WebDriver � �������� �������� ������������
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/");
            calculatorPage = new CalculatorPage(driver);
        }

        [TearDown]
        public void Teardown()
        {
            // ���������� ������ WebDriver
            driver.Quit();
        }

        [TestCase(2, 3, "2 + 3 = 5")]
        [TestCase(-10, 5, "-10 + 5 = -5")]
        [TestCase(-11, 5, "-11 + 5 = -6")]
        [TestCase(0, 4, "0 + 4 = 4")]
        [TestCase(-10, -5, "-10 + -5 = -15")]
        public void TestAddition(double a, double b, string expect) // �������� �� ��������
        {
            calculatorPage.EnterValueA(a);
            calculatorPage.EnterValueB(b);
            calculatorPage.SelectOperation("+");
            string result = calculatorPage.GetResult();
            Assert.That(expect, Is.EqualTo(result));
        }

        [TestCase(5, 2, "5 - 2 = 3")]
        [TestCase(0, -4, "0 - -4 = 4")]
        [TestCase(5, 2, "5 - 2 = 3")]
        public void TestSubtraction(double a, double b, string expect) // �������� �� ���������
        {
            calculatorPage.EnterValueA(a);
            calculatorPage.EnterValueB(b);
            calculatorPage.SelectOperation("-");
            string result = calculatorPage.GetResult();
            Assert.That(expect, Is.EqualTo(result));
        }

        [TestCase(5, 2, "5 * 2 = 10")]
        [TestCase(.2, .10, "null * null = null")]
        [TestCase(.2, 10, "null * 10 = null")]
        [TestCase(7, .3, "7 * null = null")]

        public void TestMultiplication(double a, double b, string expect) // �������� �� ���������
        {
            calculatorPage.EnterValueA(a);
            calculatorPage.EnterValueB(b);
            calculatorPage.SelectOperation("*");
            string result = calculatorPage.GetResult();
            Assert.That(expect, Is.EqualTo(result));
        }

        [TestCase(10, 2, "10 / 2 = 5")]
        public void TestDivision(double a, double b, string expect) // �������� �� �������
        {
            calculatorPage.EnterValueA(a);
            calculatorPage.EnterValueB(b);
            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(expect, Is.EqualTo(result));
        }


        //[Test]
        //public void Test6() // �������� �� �������� �������������� � �������������
        //{
        //    calculatorPage.EnterValueA(-10);
        //    calculatorPage.EnterValueB(-5);
        //    calculatorPage.SelectOperation("+");
        //    string result = calculatorPage.GetResult();
        //    Assert.That(result, Is.EqualTo("-10 + -5 = -15"));
        //}

        [Test]
        public void Test7() // �������� �� ��������� �������������� � �������������
        {
            calculatorPage.EnterValueA(-10);
            calculatorPage.EnterValueB(-5);
            calculatorPage.ButtonAMinus();
            calculatorPage.SelectOperation("+");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("-11 + -5 = -16"));
        }

        [Test]
        public void Test8() // �������� �� ��������� �������������� � �������������
        {
            calculatorPage.EnterValueA(-10);
            calculatorPage.EnterValueB(-5);
            calculatorPage.ButtonAMinus();
            calculatorPage.SelectOperation("*");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("-11 * -5 = 55"));
        }

        [Test]
        public void Test9() // �������� �� ��������� �������������� � �������������
        {
            calculatorPage.EnterValueA(10);
            calculatorPage.EnterValueB(5);
            calculatorPage.ButtonAMinus();
            calculatorPage.SelectOperation("*");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("9 * 5 = 45"));
        }

        [Test]
        public void Test10() // �������� �� ������� �������������� � �������������
        {
            calculatorPage.EnterValueA(-10);
            calculatorPage.EnterValueB(-5);
            calculatorPage.ButtonAMinus();
            calculatorPage.ButtonBPlus();
            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("-11 / -4 = 2.75"));
        }

        [Test]
        public void Test11() // �������� �� ������� �������������� � �������������
        {
            calculatorPage.EnterValueA(10);
            calculatorPage.EnterValueB(-5);
            calculatorPage.ButtonAMinus();
            calculatorPage.ButtonBPlus();
            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("9 / -4 = -2.25"));
        }

        [Test]
        public void Test12() // �������� �� ������� ��������� ��������������  � �������������
        {
            calculatorPage.EnterValueA(1000000000);
            calculatorPage.EnterValueB(-5);
            calculatorPage.ButtonAMinus();
            calculatorPage.ButtonBPlus();
            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("999999999 / -4 = -249999999.75"));
        }


        [Test]
        public void Test13() // �������� �� ��������� ����
        {
            calculatorPage.EnterValueA(5);
            calculatorPage.EnterValueB(5);
            calculatorPage.ButtonAMinus();
            calculatorPage.ButtonBMinus();
            calculatorPage.SelectOperation("-");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("4 - 4 = 0"));
        }

        [Test]
        public void Test14() // �������� �� ��������� ����
        {
            calculatorPage.EnterValueA(1);
            calculatorPage.EnterValueB(5);
            calculatorPage.ButtonAMinus();
            calculatorPage.ButtonBMinus();
            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("0 / 4 = 0"));
        }

        [Test]
        public void Test15() // �������� �� ��������� 1
        {
            calculatorPage.EnterValueA(5);
            calculatorPage.EnterValueB(5);
            calculatorPage.ButtonAMinus();
            calculatorPage.ButtonBMinus();
            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("4 / 4 = 1"));
        }

        [Test]
        public void Test16() // �������� �� ����������� �������
        {
            calculatorPage.EnterValueA(3);
            calculatorPage.EnterValueB(4);
            calculatorPage.ButtonAMinus();
            calculatorPage.ButtonBMinus();
            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("2 / 3 = 0.6666666666666666"));
        }

        [Test]
        public void Test17() // �������� �� �������� �������������� � �������������� ��� ��������� 0
        {
            calculatorPage.EnterValueA(-3);
            calculatorPage.EnterValueB(4);
            calculatorPage.ButtonAMinus();

            calculatorPage.SelectOperation("+");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("-4 + 4 = 0"));
        }

        [Test]
        public void Test18() // �������� �� ������� �������������� � ��������������
        {
            calculatorPage.EnterValueA(10);
            calculatorPage.EnterValueB(4);
            calculatorPage.ButtonAMinus();

            calculatorPage.SelectOperation("/");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("9 / 4 = 2.25"));
        }

        //[Test]
        //public void Test19() // �������� �� �������� 0 � ��������������
        //{
        //    calculatorPage.EnterValueA(0);
        //    calculatorPage.EnterValueB(4);


        //    calculatorPage.SelectOperation("+");
        //    string result = calculatorPage.GetResult();
        //    Assert.That(result, Is.EqualTo("0 + 4 = 4"));
        //}

        //[Test]
        //public void Test20() // �������� �� �������� 0 � ��������������
        //{
        //    calculatorPage.EnterValueA(0);
        //    calculatorPage.EnterValueB(-4);
        //    calculatorPage.SelectOperation("-");
        //    string result = calculatorPage.GetResult();
        //    Assert.That(result, Is.EqualTo("0 - -4 = 4"));
        //}

        [Test]
        public void Test21() // �������� �� ���� ��������� ������, � ����� ������ �� �� ����������
        {
            calculatorPage.EnterValueA(.6);
            calculatorPage.EnterValueB(-4);
            calculatorPage.EnterValueA(4);
            calculatorPage.SelectOperation("-");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("4 - -4 = 8"));
        }

        [Test]
        public void Test22() // �������� �� ���� ��������� ������, � ����� ������ �� �� ����������
        {
            calculatorPage.EnterValueA(7);
            calculatorPage.EnterValueB(.3);
            calculatorPage.EnterValueB(4);
            calculatorPage.SelectOperation("*");
            string result = calculatorPage.GetResult();
            Assert.That(result, Is.EqualTo("7 * 4 = 28"));
        }

        //[Test]
        //public void Test23() // �������� �� ���� ��������� ������
        //{
        //    calculatorPage.EnterValueA(7);
        //    calculatorPage.EnterValueB(.3);

        //    calculatorPage.SelectOperation("*");
        //    string result = calculatorPage.GetResult();
        //    Assert.That(result, Is.EqualTo("7 * null = null"));
        //}

        //[Test]
        //public void Test24() // �������� �� ���� ��������� ������
        //{
        //    calculatorPage.EnterValueA(.2);
        //    calculatorPage.EnterValueB(10);

        //    calculatorPage.SelectOperation("*");
        //    string result = calculatorPage.GetResult();
        //    Assert.That(result, Is.EqualTo("null * 10 = null"));
        //}

        //[Test]
        //public void Test25() // �������� �� ���� ��������� ������
        //{
        //    calculatorPage.EnterValueA(.2);
        //    calculatorPage.EnterValueB(.10);

        //    calculatorPage.SelectOperation("*");
        //    string result = calculatorPage.GetResult();
        //    Assert.That(result, Is.EqualTo("null * null = null"));
        //}
    }
}