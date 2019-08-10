using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace webczwUnitTest
{
    [TestClass]
    public class TotalPageUnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            int a = 5; // TODO: 初始化为适当的值
            int b = 4; // TODO: 初始化为适当的值
            int expected = 9; // TODO: 初始化为适当的值
            int actual;
            actual = add(a, b);
            Assert.AreEqual(expected, actual);
            // Assert.Inconclusive("验证此测试方法的正确性。");
            //Console.WriteLine("验证此测试方法的正确性");

            int totalNumber = 318;
            int pageSize = 15;
            int currentPage = 20;
            const int totalPageSize = 11;
            int totalPage = totalNumber / pageSize;
            if (totalNumber % pageSize != 0)
            {
                totalPage++;
            }
            Console.WriteLine("总页数：" + totalPage);

            int center = (totalPageSize / 2) + 1;
            int size = totalPageSize;
            int i = 0;

            if (totalPage < totalPageSize)
            {
                size = totalPage;
            }
            if (currentPage > center)
            {
                int deviation = currentPage - center;
                i = deviation;
                size = totalPageSize + deviation;
            }

            if ((i + totalPageSize) > totalPage) {
                i = totalPage - totalPageSize;
                size = i + totalPageSize;
            }

            for (; i < size; i++)
            {
                int page = i + 1;
                if (page == currentPage)
                {
                    Console.WriteLine("[" + page + "]");
                }
                else
                {
                    Console.WriteLine(page);
                }
            }


        }

        int add(int a, int b)
        {
            return a + b;
        }

    }
}
