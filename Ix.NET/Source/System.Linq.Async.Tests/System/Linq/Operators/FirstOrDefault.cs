﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class FirstOrDefault : AsyncEnumerableTests
    {
        [Fact]
        public async Task FirstOrDefault_Null()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.FirstOrDefault<int>(default));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.FirstOrDefault<int>(default, x => true));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.FirstOrDefault(Return42, default(Func<int, bool>)));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.FirstOrDefault<int>(default, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.FirstOrDefault<int>(default, x => true, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.FirstOrDefault(Return42, default(Func<int, bool>), CancellationToken.None));
        }

        [Fact]
        public void FirstOrDefault1()
        {
            var res = AsyncEnumerable.Empty<int>().FirstOrDefault();
            Assert.Equal(0, res.Result);
        }

        [Fact]
        public void FirstOrDefault2()
        {
            var res = AsyncEnumerable.Empty<int>().FirstOrDefault(x => true);
            Assert.Equal(0, res.Result);
        }

        [Fact]
        public void FirstOrDefault3()
        {
            var res = Return42.FirstOrDefault(x => x % 2 != 0);
            Assert.Equal(0, res.Result);
        }

        [Fact]
        public void FirstOrDefault4()
        {
            var res = Return42.FirstOrDefault();
            Assert.Equal(42, res.Result);
        }

        [Fact]
        public void FirstOrDefault5()
        {
            var res = Return42.FirstOrDefault(x => x % 2 == 0);
            Assert.Equal(42, res.Result);
        }

        [Fact]
        public void FirstOrDefault6()
        {
            var ex = new Exception("Bang!");
            var res = Throw<int>(ex).FirstOrDefault();
            AssertThrowsAsync(res, ex);
        }

        [Fact]
        public void FirstOrDefault7()
        {
            var ex = new Exception("Bang!");
            var res = Throw<int>(ex).FirstOrDefault(x => true);
            AssertThrowsAsync(res, ex);
        }

        [Fact]
        public void FirstOrDefault8()
        {
            var res = new[] { 42, 45, 90 }.ToAsyncEnumerable().FirstOrDefault();
            Assert.Equal(42, res.Result);
        }

        [Fact]
        public void FirstOrDefault9()
        {
            var res = new[] { 42, 45, 90 }.ToAsyncEnumerable().FirstOrDefault(x => x % 2 != 0);
            Assert.Equal(45, res.Result);
        }

        [Fact]
        public void FirstOrDefault10()
        {
            var res = new[] { 42, 45, 90 }.ToAsyncEnumerable().FirstOrDefault(x => x < 10);
            Assert.Equal(0, res.Result);
        }
    }
}
