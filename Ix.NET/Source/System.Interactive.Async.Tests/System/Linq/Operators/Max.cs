﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Max : AsyncEnumerableExTests
    {
        [Fact]
        public async Task Max_Null()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerableEx.MaxAsync(default, Comparer<DateTime>.Default).AsTask());

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerableEx.MaxAsync(default, Comparer<DateTime>.Default, CancellationToken.None).AsTask());
        }
    }
}
