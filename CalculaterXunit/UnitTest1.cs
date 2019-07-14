using System;
using Xunit;

namespace CalculaterXunit
{
    public class UnitTest1
    {
        HttpReq req = new HttpReq();
        //adhttps://localhost:44300/add/1?id1=1&id2=2
        [Fact]
        public void Test1()
        {
            var expectedValue = "3";
            var add = req.GetCall("https://localhost:44300/add/1?id1=1&id2=2");
            Assert.Equal(expectedValue, add);
        }
        [Fact]
        public void Test2()
        {
            var data = "{\r\n\t\"num1\": 1,\r\n\t\"num2\": 2\r\n}";
            float expectedValue = 3;
            var add = float.Parse(req.PostCall("https://localhost:44300/add", data));
            Assert.Equal(expectedValue, add);
        }
        [Theory]
        [InlineData(3,1,2)]        
        public void addTest3(float expected, float num1, float num2)
        {
            var data = "{\r\n\t\"num1\": "+num1+",\r\n\t\"num2\":"+num2+"\r\n}";
            //var expectedValue = "3";
            var add =float.Parse(req.PostCall("https://localhost:44300/add", data));
            Assert.Equal(expected, add);
        }
        [Theory]
        [InlineData(2,4,2)]
        [InlineData(0, 0, 1)]
        public void divTest1(float expected, float num1, float num2)
        {
            var data = "{\r\n\t\"num1\": " + num1 + ",\r\n\t\"num2\":" + num2 + "\r\n}";
            if (num2 == 0)
            {
                //Exception ex = Assert.Throws<ValidationException>(() => ca.division(num1,num2));
                //Assert.Equal(String.Format("dividend should be greater than 0", num2), ex.Message);
                Assert.Throws<DivideByZeroException>(() => float.Parse(req.PostCall("https://localhost:44300/division", data)));
            }
            else
            {                             
                var div = float.Parse(req.PostCall("https://localhost:44300/division", data));
                Assert.Equal(expected, div);
            }                            
        }
        [Theory]
        [InlineData(3, 5, 2)]
        [InlineData(-8, 1, 9)]
        public void subTest(float expected, float num1, float num2)
        {
            var data = "{\r\n\t\"num1\": " + num1 + ",\r\n\t\"num2\":" + num2 + "\r\n}";
            //var expectedValue = "3";
            var add = float.Parse(req.PostCall("https://localhost:44300/subtract", data));
            Assert.Equal(expected, add);
        }
        [Theory]
        [InlineData(3, 1, 3)]
        [InlineData(9, 1, 9)]
        public void multiplyTest(float expected, float num1, float num2)
        {
            var data = "{\r\n\t\"num1\": " + num1 + ",\r\n\t\"num2\":" + num2 + "\r\n}";
            //var expectedValue = "3";
            var add = float.Parse(req.PostCall("https://localhost:44300/multiply", data));
            Assert.Equal(expected, add);
        }
    }
}
