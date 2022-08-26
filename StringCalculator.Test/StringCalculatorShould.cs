using NUnit.Framework;
using System;

namespace StringCalculator.Test
{
    public class Tests
    {


        [Test]
        public void AddEmptyString()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("");

            Assert.That(result, Is.EqualTo(0));

        }

        [Test]
        public void AddOnlyOneNumber()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("1");

            Assert.That(result, Is.EqualTo(1));

        }


        [Test]
        public void AddTwoNumbers()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("1,2");

            Assert.That(result, Is.EqualTo(3));

        }


        [Test]
        public void AddManyNumbers()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("1,2,3,4");

            Assert.That(result, Is.EqualTo(10));

        }

        [Test]
        public void AddWithDifferentSigns()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("1\n2,3");

            Assert.That(result, Is.EqualTo(6));

        }


        [Test]
        public void AddDelimiter()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//;\n1;2;3");

            Assert.That(result, Is.EqualTo(6));

        }


        [Test]
        public void AddNegativesNumber()
        {
            var calculator = new StringCalculator();
            
            Assert.That(() => calculator.Add("//;\n1;-2;4;-3"), Throws.TypeOf<Exception>()
             .With
             .Message
             .EqualTo("negatives not allowed: -2;-3;"));

        }

        [Test]
        public void AddNumbersMoreThen1000()
        {
            var calculator = new StringCalculator();

            int result = calculator.Add("//;\n1;2;3;1006");

            Assert.That(result, Is.EqualTo(6));

        }
        [Test]
        public void AddManyDelimiters()
        {
            var calculator = new StringCalculator();

            int result = calculator.Add("//[***]\n1***2***3");

            Assert.That(result, Is.EqualTo(6));

        }

        [Test]
        public void AddManyDelimiters2()
        {
            var calculator = new StringCalculator();

            int result = calculator.Add("//[*][%]\n1*2%3");

            Assert.That(result, Is.EqualTo(6));

        }

        [Test]
        public void AddManyDelimitersAndNegativeNumbers()
        {
            var calculator = new StringCalculator();

            Assert.That(() => calculator.Add("//[*][%]\n-1*2%-3"), Throws.TypeOf<Exception>()
            .With
            .Message
            .EqualTo("negatives not allowed: -1;-3;"));

        }

    }
}