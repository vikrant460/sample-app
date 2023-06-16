using DDDExamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmailSender.Core.Test
{
    public  class Tests
    {
        [Fact]
        public void Test1()
        {
            var numbers = new int[] {1,2,3 };
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 6;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test2()
        {
            var numbers = new int[] { 1, -1 };
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 1;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test3()
        {
            var numbers = new int[] {};
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 0;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test4()
        {
            var numbers = new int[] {-1,1 };
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 1;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test5()
        {
            var numbers = new int[] { -1, 1 };
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 1;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test6()
        {
            var numbers = new int[] { 1, 2, -3 };
            var maxAllowedStep =1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 3;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test7()
        {
            var numbers = new int[] { -1, -2, 3 };
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 3;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test8()
        {
            var numbers = new int[] { 1, 1};
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 2;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test9()
        {
            var numbers = new int[] { 0 };
            var maxAllowedStep = 1;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 0;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test10()
        {
            var numbers = new int[] { 1,-1,1 };
            var maxAllowedStep = 2;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 2;
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Test11()
        {
            var numbers = new int[] { 1, -1, -1,1 };
            var maxAllowedStep = 2;
            var program = new MaxScoreService();
            var actualScore = program.GetMaximumScore(numbers, maxAllowedStep);
            var expectedScore = 2;
            Assert.Equal(expectedScore, actualScore);
        }
    }
}
